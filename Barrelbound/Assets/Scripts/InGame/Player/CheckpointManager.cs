using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance;

    public Vector3 currentCheckpoint;

    [Header("Default Spawn")]
    public Vector3 defaultSpawn;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            if (transform.parent != null)
                transform.SetParent(null);

            DontDestroyOnLoad(gameObject);

            currentCheckpoint = defaultSpawn;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCheckpoint(Vector3 newCheckpoint)
    {
        currentCheckpoint = newCheckpoint;

        Debug.Log("Checkpoint set: " + newCheckpoint);
    }

    public Vector3 GetSpawnPosition()
    {
        return currentCheckpoint;
    }

    public void ResetCheckpoint()
    {
        currentCheckpoint = defaultSpawn;
    }
}