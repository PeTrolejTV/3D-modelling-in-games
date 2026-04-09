using UnityEngine;

[RequireComponent(typeof(Collider))]
public class TimerTrigger : MonoBehaviour
{
    public enum TimerAction { Start, Stop, Reset, Toggle }

    public string playerTag = "Player";
    public TimerAction action = TimerAction.Start;
    public bool triggerOnce = false;
    public bool startInBackground = false;

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(playerTag)) return;
        if (triggerOnce && hasTriggered) return;

        var speedrunManager = FindFirstObjectByType<SpeedrunManager>();
        if (speedrunManager == null) return;

        switch (action)
        {
            case TimerAction.Start:
                speedrunManager.StartTimer(startInBackground);
                break;
            case TimerAction.Stop:
                speedrunManager.StopTimer();
                break;
            case TimerAction.Reset:
                speedrunManager.ResetTimer();
                break;
            case TimerAction.Toggle:
                if (speedrunManager.IsRunning)
                    speedrunManager.StopTimer();
                else
                    speedrunManager.StartTimer(startInBackground);
                break;
        }

        hasTriggered = true;
    }

    public void ResetTrigger()
    {
        hasTriggered = false;
    }
}