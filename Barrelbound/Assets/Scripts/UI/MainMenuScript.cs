using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuScript : MonoBehaviour
{
    [Header("Object Explosion Settings")]
    [Tooltip("Assign the Object with ObjectExplode script here")]
    public ObjectExplode objectToExplode;

    [Header("UI Settings")]
    [Tooltip("Assign your Main Menu Canvas here")]
    public Canvas mainMenuCanvas;

    public float delayBeforeLoad = 3f;

    public void PlayGame()
    {
        if (mainMenuCanvas != null)
        {
            mainMenuCanvas.enabled = false;
        }
        else
        {
            Debug.LogWarning("Main Menu Canvas is not assigned! UI will stay visible.");
        }

        if (objectToExplode != null)
        {
            objectToExplode.BreakObject();
        }
        else
        {
            Debug.LogWarning("ObjectExplode reference is not assigned!");
        }

        StartCoroutine(LoadLevelAfterDelay());
    }

    private IEnumerator LoadLevelAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeLoad);
        SceneManager.LoadScene("Game");
        SceneManager.LoadScene("StartingArea", LoadSceneMode.Additive);
    }

    public void QuitGame()
    {
        Debug.Log("Game is quitting...");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}