using UnityEngine;

public class DeathTrigger : MonoBehaviour
{
    public enum TriggerMode { OnTrigger, OnCollision }

    [Header("Settings")]
    public TriggerMode triggerMode = TriggerMode.OnTrigger;
    public string playerTag = "Player";
    public bool oneShot = true;
    public bool destroySelf = false;

    private bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (triggerMode != TriggerMode.OnTrigger) return;
        HandleDeath(other.gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (triggerMode != TriggerMode.OnCollision) return;
        HandleDeath(collision.gameObject);
    }

    private void HandleDeath(GameObject obj)
    {
        if (triggered && oneShot) return;
        if (!obj.CompareTag(playerTag)) return;

        triggered = true;

        if (DeathManager.Instance != null)
            DeathManager.Instance.KillPlayer();

        if (destroySelf)
            Destroy(gameObject);
    }
}