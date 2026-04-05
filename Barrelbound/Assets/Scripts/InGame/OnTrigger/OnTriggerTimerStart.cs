using UnityEngine;

public class OnTriggerTimerStart : MonoBehaviour
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
        speedrunTimer.StartTimer();
    }

    public void ResetTrigger() => _triggered = false;
}