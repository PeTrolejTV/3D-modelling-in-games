using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [Header("Target to rotate around")]
    [Tooltip("Drag the object you want to orbit here (e.g. your barrel)")]
    public Transform target;

    [Header("Rotation Settings")]
    [Tooltip("Rotation speed in degrees per second")]
    public float rotationSpeed = 30f;

    [Tooltip("Rotate clockwise (true) or counter-clockwise (false)")]
    public bool clockwise = true;

    [Header("Advanced (optional)")]
    [Tooltip("If enabled, locks to a fixed orbit distance (ignores starting distance)")]
    public bool useFixedDistance = false;
    [Tooltip("Fixed distance from target when useFixedDistance is true")]
    public float fixedDistance = 5f;

    private Vector3 initialOffset;

    void Start()
    {
        if (target == null)
        {
            Debug.LogWarning("No target assigned to RotateAround on " + gameObject.name);
            enabled = false;
            return;
        }

        initialOffset = transform.position - target.position;
    }

    void LateUpdate()
    {
        if (target == null) return;
        Vector3 currentDirection = transform.position - target.position;

        if (useFixedDistance)
        {
            currentDirection = currentDirection.normalized * fixedDistance;
        }
        
        float angleThisFrame = rotationSpeed * Time.deltaTime;

        if (!clockwise) angleThisFrame = -angleThisFrame;

        currentDirection = Quaternion.Euler(0f, angleThisFrame, 0f) * currentDirection;

        transform.position = target.position + currentDirection;

        transform.LookAt(target);
    }
}