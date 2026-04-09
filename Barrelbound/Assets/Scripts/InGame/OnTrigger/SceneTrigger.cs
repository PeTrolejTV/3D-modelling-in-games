using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]
public class SceneTrigger : MonoBehaviour
{
    public enum TriggerMode { Load, Unload, Toggle }

    [Header("Scene Settings")]
    public string sceneName;

    [Header("Trigger Settings")]
    public TriggerMode mode = TriggerMode.Toggle;
    public bool triggerOnce = true;

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (triggerOnce && hasTriggered) return;

        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogWarning($"[SceneTrigger] Scene name is empty on '{gameObject.name}'.");
            return;
        }

        switch (mode)
        {
            case TriggerMode.Load:
                if (IsSceneLoaded()) return;
                LoadScene();
                break;

            case TriggerMode.Unload:
                if (!IsSceneLoaded()) return;
                UnloadScene();
                break;

            case TriggerMode.Toggle:
                if (IsSceneLoaded())
                    UnloadScene();
                else
                    LoadScene();
                break;
        }

        hasTriggered = true;
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