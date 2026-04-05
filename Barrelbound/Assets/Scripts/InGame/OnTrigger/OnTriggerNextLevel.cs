using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class OnTriggerNextLevel : MonoBehaviour
{
    [Header("Next Level Settings")]
    [Tooltip("Build index of the next level scene to load (Level1 = 3, Level2 = 4, etc.)")]
    public int nextLevelBuildIndex = 3;

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (hasTriggered) return;

        if (IsSceneAlreadyLoaded(nextLevelBuildIndex))
        {
            return;
        }

        hasTriggered = true;
        StartCoroutine(TransitionToNextLevel());
    }

    private bool IsSceneAlreadyLoaded(int buildIndex)
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.buildIndex == buildIndex && scene.isLoaded)
            {
                return true;
            }
        }
        return false;
    }

    private IEnumerator TransitionToNextLevel()
    {
        AsyncOperation loadOp = SceneManager.LoadSceneAsync(nextLevelBuildIndex, LoadSceneMode.Additive);
        yield return new WaitUntil(() => loadOp.isDone);

        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (scene.name != "Game" && scene.isLoaded)
            {
                AsyncOperation unloadOp = SceneManager.UnloadSceneAsync(scene);
                yield return new WaitUntil(() => unloadOp.isDone);
                break;
            }
        }
    }
}