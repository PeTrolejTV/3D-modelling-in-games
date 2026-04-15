using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ItemDestroyerBarrier : MonoBehaviour
{
    [SerializeField] private float destructionDelay = 1f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            return;

        Rigidbody rb = other.attachedRigidbody;
        if (rb == null)
            return;

        Vector3 savedVelocity = rb.linearVelocity;
        Vector3 savedAngularVelocity = rb.angularVelocity;

        Pickupable pickup = rb.GetComponent<Pickupable>();
        if (pickup != null)
        {
            pickup.Drop();
            Destroy(pickup);
        }

        rb.useGravity = false;

        ObjectExplode explode = rb.GetComponent<ObjectExplode>();
        if (explode != null)
        {
            DisassembleObject(explode, savedVelocity, savedAngularVelocity);
        }

        Destroy(rb.gameObject, destructionDelay);
    }

    private void DisassembleObject(ObjectExplode explodeComponent, Vector3 savedVelocity, Vector3 savedAngularVelocity)
    {
        Transform[] allParts = explodeComponent.GetComponentsInChildren<Transform>();
        Rigidbody mainRb = explodeComponent.GetComponent<Rigidbody>();

        foreach (Transform part in allParts)
        {
            if (part == explodeComponent.transform) continue;

            Joint joint = part.GetComponent<Joint>();
            if (joint != null)
                Destroy(joint);

            Rigidbody partRb = part.GetComponent<Rigidbody>();
            if (partRb == null)
            {
                partRb = part.gameObject.AddComponent<Rigidbody>();
            }

            partRb.mass = 1f;
            partRb.linearDamping = 0f;
            partRb.angularDamping = 0f;
            partRb.useGravity = true;

            partRb.linearVelocity = savedVelocity;
            partRb.angularVelocity = savedAngularVelocity;
        }

        if (mainRb != null)
        {
            Destroy(mainRb);
        }
    }
}