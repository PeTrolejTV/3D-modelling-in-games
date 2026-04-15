using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool activated = false;

    private void OnTriggerEnter(Collider other)
    {
        if (activated) return;

        if (other.CompareTag("Player"))
        {
            CheckpointManager.Instance.SetCheckpoint(other.transform.position);

            activated = true;
        }
    }
}