using UnityEngine;
using UnityEngine.InputSystem;

public class BarrelExplode : MonoBehaviour
{
    [Header("Break Settings")]
    public float explosionForce = 8f;
    public float upwardForce = 3f;

    [Header("Collision Settings")]
    public float breakVelocityThreshold = 8f;

    private Transform[] allParts;
    private bool isBroken = false;

    private Rigidbody mainRb;

    void Start()
    {
        allParts = GetComponentsInChildren<Transform>();

        mainRb = GetComponent<Rigidbody>();
        if (mainRb == null)
        {
            mainRb = gameObject.AddComponent<Rigidbody>();
        }
    }

    void Update()
    {
        if (!isBroken && Keyboard.current.eKey.wasPressedThisFrame)
        {
            BreakTheBarrel();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (isBroken) return;

        float impact = collision.relativeVelocity.magnitude;

        if (impact >= breakVelocityThreshold)
        {
            Debug.Log("Barrel broke from impact! Impact: " + impact);
            BreakTheBarrel();
        }
    }

    public void BreakTheBarrel()
    {
        isBroken = true;

        if (mainRb != null)
        {
            Destroy(mainRb);
        }

        foreach (Transform part in allParts)
        {
            if (part == transform) continue;

            Rigidbody rb = part.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = part.gameObject.AddComponent<Rigidbody>();
            }

            rb.mass = 1f;
            rb.linearDamping = 0f;
            rb.angularDamping = 0f;
            rb.useGravity = true;

            Vector3 force = Random.insideUnitSphere * explosionForce;
            force.y += upwardForce;

            rb.AddForce(force, ForceMode.Impulse);
            rb.AddTorque(Random.insideUnitSphere * 5f, ForceMode.Impulse);

            Joint joint = part.GetComponent<Joint>();
            if (joint != null) Destroy(joint);
        }
    }

    [ContextMenu("Break Barrel Now (Test)")]
    void TestBreak()
    {
        BreakTheBarrel();
    }
}