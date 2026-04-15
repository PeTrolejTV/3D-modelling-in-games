using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenuScript : MonoBehaviour
{
    [Header("Object Explosion Settings")]
    public ObjectExplode objectToExplode;
    [Header("UI Settings")]
    public Canvas mainMenuCanvas;
    public float delayBeforeLoad = 3f;

    public void PlayGame()
    {
        if (mainMenuCanvas != null)
            mainMenuCanvas.enabled = false;
        if (objectToExplode != null)
            objectToExplode.BreakObject();
        StartCoroutine(LoadLevelAfterDelay());
    }

    private IEnumerator LoadLevelAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeLoad);
        
        SceneManager.LoadScene("Game");
        SceneManager.LoadScene("StartingArea", LoadSceneMode.Additive);

        StartCoroutine(ForceSetStartingAreaActive());
    }

    private System.Collections.IEnumerator ForceSetStartingAreaActive()
    {
        yield return new WaitForSeconds(0.1f);
        ActiveSceneManager.ForceSetActiveScene("StartingArea");
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