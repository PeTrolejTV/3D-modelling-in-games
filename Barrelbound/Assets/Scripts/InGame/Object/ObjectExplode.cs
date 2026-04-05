using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectExplode : MonoBehaviour
{
    public float explosionForce = 8f;
    public float upwardForce = 3f;
    public float breakVelocityThreshold = 8f;
    public Key explodeKey = Key.E;

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
        if (!isBroken && Keyboard.current[explodeKey].wasPressedThisFrame)
        {
            BreakObject();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (isBroken) return;
        float impact = collision.relativeVelocity.magnitude;
        if (impact >= breakVelocityThreshold)
        {
            BreakObject();
        }
    }

    public void BreakObject()
    {
        isBroken = true;

        Pickupable pickupComp = GetComponent<Pickupable>();
        if (pickupComp != null)
        {
            Destroy(pickupComp);
        }

        foreach (Transform part in allParts)
        {
            if (part == transform) continue;

            Joint joint = part.GetComponent<Joint>();
            if (joint != null) Destroy(joint);

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
        }

        if (mainRb != null)
        {
            Destroy(mainRb);
        }
    }
}