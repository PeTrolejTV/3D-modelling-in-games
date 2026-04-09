using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour, IInteractable
{
    public enum ButtonMode { Load, Unload, Toggle }

    [Header("Scene Settings")]
    public string sceneName;

    [Header("Button Settings")]
    public ButtonMode mode = ButtonMode.Toggle;

    public void Interact(PlayerController player)
    {
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogWarning($"[SceneButton] Scene name is empty on '{gameObject.name}'.");
            return;
        }

        switch (mode)
        {
            case ButtonMode.Load:
                if (IsSceneLoaded()) return;
                LoadScene();
                break;

            case ButtonMode.Unload:
                if (!IsSceneLoaded()) return;
                UnloadScene();
                break;

            case ButtonMode.Toggle:
                if (IsSceneLoaded())
                    UnloadScene();
                else
                    LoadScene();
                break;
        }
    }

    private void LoadScene()
    {
        if (IsSceneLoaded()) return;
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }

    private void UnloadScene()
    {
        if (!IsSceneLoaded()) return;
        SceneManager.UnloadSceneAsync(sceneName);
    }

    private bool IsSceneLoaded()
    {
        Scene scene = SceneManager.GetSceneByName(sceneName);
        return scene.isLoaded;
    }
}