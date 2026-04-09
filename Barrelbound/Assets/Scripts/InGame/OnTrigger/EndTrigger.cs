using UnityEngine;

[RequireComponent(typeof(Collider))]
public class EndTrigger : MonoBehaviour
{
    public string playerTag = "Player";
    public bool oneShot = true;

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggered && oneShot) return;
        if (!other.CompareTag(playerTag)) return;

        triggered = true;

        if (EndManager.Instance != null)
            EndManager.Instance.TriggerEnd();
        else
            Debug.LogWarning("EndManager instance not found in scene!");
    }
}