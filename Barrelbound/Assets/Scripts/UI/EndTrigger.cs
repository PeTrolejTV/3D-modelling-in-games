using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    [Header("UI")]
    public GameObject endScreenUI;
    public GameObject crosshair;

    [Header("Player")]
    public PlayerController playerController;

    [Header("Speedrun")]
    public SpeedrunTimer speedrunTimer;

    [Header("Settings")]
    public string playerTag = "Player";
    public bool oneShot = true;

    private bool _triggered = false;

    private void Awake()
    {
        if (endScreenUI != null)
            endScreenUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_triggered && oneShot) return;
        if (!other.CompareTag(playerTag)) return;
        _triggered = true;
        ShowEndScreen();
    }

    private void ShowEndScreen()
    {
        endScreenUI.SetActive(true);

        if (crosshair != null)
            crosshair.SetActive(false);

        Time.timeScale = 0f;

        if (playerController != null)
        {
            playerController.DisableControls();
            playerController.canLook = false;
        }

        if (speedrunTimer != null)
            speedrunTimer.SetIngameTimerVisible(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}