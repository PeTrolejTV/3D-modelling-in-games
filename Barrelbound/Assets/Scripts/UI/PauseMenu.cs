using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [Header("UI")]
    public GameObject pauseMenuUI;
    public GameObject crosshair;
    public Toggle speedrunToggle;
    [Header("Player")]
    public PlayerController playerController;
    [Header("Speedrun")]
    public SpeedrunManager speedrunManager;

    private PlayerInputActions controls;
    private bool isPaused = false;
    private bool objectiveWasActiveBeforePause = false;

    void Awake()
    {
        controls = new PlayerInputActions();
        controls.UI.Pause.performed += ctx => TogglePause();
    }

    void OnEnable()
    {
        controls.Enable();
        SyncSpeedrunToggle();
    }

    void Start()
    {
        SyncSpeedrunToggle();
    }

    void OnDisable()
    {
        controls.Disable();
    }

    private void SyncSpeedrunToggle()
    {
        if (speedrunToggle != null)
            speedrunToggle.isOn = SpeedrunManager.SpeedrunEnabled;
        if (speedrunManager != null)
            speedrunManager.SetEnabled(SpeedrunManager.SpeedrunEnabled);
    }

    void TogglePause()
    {
        if (GameState.IsGameOver) return;
        if (isPaused) Resume();
        else Pause();
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        crosshair.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
        playerController.EnableControls();
        playerController.canLook = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (speedrunManager != null)
            speedrunManager.SetIngameTimerVisible(true);
       
        SpeedrunManager.AnyMenuOpen = false;
        if (ObjectiveUI.Instance != null && objectiveWasActiveBeforePause)
            ObjectiveUI.Instance.ShowUI();
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        crosshair.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
        playerController.DisableControls();
        playerController.canLook = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        if (speedrunManager != null)
            speedrunManager.SetIngameTimerVisible(false);
       
        SpeedrunManager.AnyMenuOpen = true;
        if (ObjectiveUI.Instance != null)
        {
            objectiveWasActiveBeforePause = ObjectiveUI.Instance.IsUIActive();
            ObjectiveUI.Instance.HideUI();
        }
        SyncSpeedrunToggle();
    }

    public void ToggleSpeedrun(bool value)
    {
        SpeedrunManager.SpeedrunEnabled = value;
    }

    public void Restart()
    {
        GameState.IsGameOver = false;
        SpeedrunManager.AnyMenuOpen = false;
        Time.timeScale = 1f;

        int sceneCount = SceneManager.sceneCount;
        int[] sceneBuildIndices = new int[sceneCount];
        for (int i = 0; i < sceneCount; i++)
            sceneBuildIndices[i] = SceneManager.GetSceneAt(i).buildIndex;

        if (sceneBuildIndices.Length > 0)
        {
            SceneManager.LoadScene(sceneBuildIndices[0], LoadSceneMode.Single);
            
            for (int i = 1; i < sceneBuildIndices.Length; i++)
                SceneManager.LoadScene(sceneBuildIndices[i], LoadSceneMode.Additive);

            if (sceneBuildIndices.Length > 1)
            {
                int lastBuildIndex = sceneBuildIndices[sceneBuildIndices.Length - 1];
                Scene lastScene = SceneManager.GetSceneByBuildIndex(lastBuildIndex);
                if (lastScene.isLoaded && lastScene.IsValid())
                {
                    SceneManager.SetActiveScene(lastScene);
                }
            }
        }

        StartCoroutine(ForceLastSceneActiveAfterRestart(sceneBuildIndices));
    }

    private System.Collections.IEnumerator ForceLastSceneActiveAfterRestart(int[] buildIndices)
    {
        yield return new WaitForSeconds(0.2f);
        if (buildIndices.Length > 1)
        {
            Scene lastScene = SceneManager.GetSceneByBuildIndex(buildIndices[buildIndices.Length - 1]);
            if (lastScene.isLoaded)
                ActiveSceneManager.ForceSetActiveScene(lastScene.name);
        }
    }

    public void MainMenu()
    {
        GameState.IsGameOver = false;
        TriggerObjectToggleSession.ClearSession();
        Time.timeScale = 1f;
        if (CheckpointManager.Instance != null)
            CheckpointManager.Instance.ResetCheckpoint();
        if (speedrunManager != null)
        {
            SpeedrunManager.ClearTimerData();
            speedrunManager.ResetTimer();
        }
        SpeedrunManager.SpeedrunEnabled = false;
        SpeedrunManager.AnyMenuOpen = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        GameState.IsGameOver = false;
        TriggerObjectToggleSession.ClearSession();
        if (speedrunManager != null)
        {
            SpeedrunManager.ClearTimerData();
            speedrunManager.ResetTimer();
        }
        SpeedrunManager.SpeedrunEnabled = false;
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}