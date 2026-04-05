using UnityEngine;

public class OnTriggerTimerEnd : MonoBehaviour
{
    [Header("References")]
    public SpeedrunTimer speedrunTimer;

    [Header("Settings")]
    public string playerTag = "Player";
    public bool oneShot = true;

    private bool _triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (_triggered && oneShot) return;
        if (!other.CompareTag(playerTag)) return;

        _triggered = true;
        speedrunTimer.StopTimer();
    }

    public void ResetTrigger() => _triggered = false;
}