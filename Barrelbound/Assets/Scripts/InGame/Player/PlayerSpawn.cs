using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    void Start()
    {
        transform.position = CheckpointManager.Instance.GetSpawnPosition();
    }
}