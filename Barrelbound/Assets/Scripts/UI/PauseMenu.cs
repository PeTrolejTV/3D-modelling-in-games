using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    [Header("UI")]
    public GameObject pauseMenuUI;
    public GameObject crosshair;

    [Header("Player")]
    public PlayerController playerController;

    [Header("Speedrun")]
    public SpeedrunTimer speedrunTimer;

    private PlayerInputActions controls;
    private bool isPaused = false;

    void Awake()
    {
        controls = new PlayerInputActions();
        controls.UI.Pause.performed += ctx => TogglePause();
    }

    void OnEnable() => controls.Enable();
    void OnDisable() => controls.Disable();

    void TogglePause()
    {
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

        if (speedrunTimer != null)
            speedrunTimer.SetIngameTimerVisible(true);
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

        if (speedrunTimer != null)
            speedrunTimer.SetIngameTimerVisible(false);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        int sceneCount = SceneManager.sceneCount;
        int[] sceneBuildIndices = new int[sceneCount];
        for (int i = 0; i < sceneCount; i++)
            sceneBuildIndices[i] = SceneManager.GetSceneAt(i).buildIndex;

        SceneManager.sceneLoaded += OnSceneLoaded;
        if (sceneBuildIndices.Length > 0)
        {
            SceneManager.LoadScene(sceneBuildIndices[0], LoadSceneMode.Single);
            for (int i = 1; i < sceneBuildIndices.Length; i++)
                SceneManager.LoadScene(sceneBuildIndices[i], LoadSceneMode.Additive);
        }
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null && CheckpointManager.Instance != null)
            player.transform.position = CheckpointManager.Instance.GetSpawnPosition();
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        if (CheckpointManager.Instance != null)
            CheckpointManager.Instance.ResetCheckpoint();
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}