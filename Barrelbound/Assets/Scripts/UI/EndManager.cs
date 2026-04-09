using UnityEngine;
using UnityEngine.UI;

public class EndManager : MonoBehaviour
{
    public static EndManager Instance { get; private set; }

    [Header("UI")]
    public GameObject endScreenUI;
    public GameObject crosshair;
    public Toggle speedrunToggle;

    [Header("Player")]
    public PlayerController playerController;

    [Header("Speedrun")]
    public SpeedrunManager speedrunManager;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        if (endScreenUI != null)
            endScreenUI.SetActive(false);
    }

    private void OnEnable()
    {
        SyncSpeedrunUI();
    }

    private void Start()
    {
        SyncSpeedrunUI();
    }

    private void SyncSpeedrunUI()
    {
        if (speedrunToggle != null)
            speedrunToggle.isOn = SpeedrunManager.SpeedrunEnabled;

        if (speedrunManager != null)
            speedrunManager.SetEnabled(SpeedrunManager.SpeedrunEnabled);
    }

    public void TriggerEnd()
    {
        GameState.IsGameOver = true;
        SpeedrunManager.AnyMenuOpen = true;

        if (endScreenUI != null) endScreenUI.SetActive(true);
        if (crosshair != null) crosshair.SetActive(false);
        
        Time.timeScale = 0f;

        if (playerController != null)
        {
            playerController.DisableControls();
            playerController.canLook = false;
        }

        if (speedrunManager != null)
            speedrunManager.SetIngameTimerVisible(false);

        if (ObjectiveUI.Instance != null)
            ObjectiveUI.Instance.HideUI();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        SyncSpeedrunUI();
    }
}