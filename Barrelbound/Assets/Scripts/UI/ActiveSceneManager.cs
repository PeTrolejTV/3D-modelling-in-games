using UnityEngine;
using UnityEngine.SceneManagement;

public class ActiveSceneManager : MonoBehaviour
{
    private static ActiveSceneManager instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (mode == LoadSceneMode.Additive)
        {
            StartCoroutine(SetActiveSceneNextFrame(scene));
        }
    }

    private System.Collections.IEnumerator SetActiveSceneNextFrame(Scene scene)
    {
        yield return null;
        yield return null;

        if (scene.isLoaded && scene.IsValid())
        {
            SceneManager.SetActiveScene(scene);
            Debug.Log($"[ActiveSceneManager] Aktívna scéna nastavená na: <color=green>{scene.name}</color>");
        }
    }

    public static void ForceSetActiveScene(string sceneName)
    {
        Scene scene = SceneManager.GetSceneByName(sceneName);
        if (scene.isLoaded && scene.IsValid())
        {
            SceneManager.SetActiveScene(scene);
            Debug.Log($"[ActiveSceneManager] Force nastavená scéna: {scene.name}");
        }
    }
}