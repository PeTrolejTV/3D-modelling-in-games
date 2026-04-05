using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Pickupable : MonoBehaviour, IInteractable
{
    public float positionSpring = 180f;
    public float positionDamping = 18f;
    public float maxHoldVelocity = 20f;
    public float rotationDamping = 8f;
    public float throwBoostMultiplier = 0.1f;

    private Rigidbody rb;
    private Collider[] ownColliders;
    private Collider[] playerColliders;
    private Transform cam;
    private bool isHeld;
    private float savedDrag;
    private float savedAngularDrag;
    private bool savedGravity;
    private Vector3 prevTargetPos;
    private Vector3 smoothedTargetVelocity;
    private float holdDistance;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ownColliders = GetComponentsInChildren<Collider>(true);
    }

    private void FixedUpdate()
    {
        if (!isHeld || cam == null) return;

        Vector3 targetPos = cam.position + cam.forward * holdDistance;
        Vector3 rawTargetVelocity = (targetPos - prevTargetPos) / Time.fixedDeltaTime;
        smoothedTargetVelocity = Vector3.Lerp(smoothedTargetVelocity, rawTargetVelocity, 0.25f);
        prevTargetPos = targetPos;

        Vector3 toTarget = targetPos - rb.position;
        Vector3 force = toTarget * positionSpring - rb.linearVelocity * positionDamping;
        rb.AddForce(force, ForceMode.Acceleration);

        if (rb.linearVelocity.sqrMagnitude > maxHoldVelocity * maxHoldVelocity)
            rb.linearVelocity = rb.linearVelocity.normalized * maxHoldVelocity;

        Quaternion targetRot = Quaternion.LookRotation(cam.forward, cam.up);
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRot, rotationDamping * Time.fixedDeltaTime));
    }

    public void Pickup(Transform playerCamera, Collider[] collidersToIgnore, float interactionDistance)
    {
        if (isHeld) return;

        cam = playerCamera;
        isHeld = true;
        playerColliders = collidersToIgnore;
        holdDistance = interactionDistance;

        Animator anim = GetComponent<Animator>();
        if (anim != null)
            Destroy(anim);

        var explode = GetComponent<ObjectExplode>();
        if (explode != null)
            explode.enabled = true;

        rb.isKinematic = false;
        rb.useGravity = true;

        savedDrag = rb.linearDamping;
        savedAngularDrag = rb.angularDamping;
        savedGravity = rb.useGravity;

        rb.useGravity = false;
        rb.linearDamping = 1f;
        rb.angularDamping = 12f;

        prevTargetPos = cam.position + cam.forward * holdDistance;
        smoothedTargetVelocity = Vector3.zero;

        foreach (Collider pc in playerColliders)
            foreach (Collider oc in ownColliders)
                Physics.IgnoreCollision(oc, pc, true);
    }

    public void Drop()
    {
        if (!isHeld) return;

        isHeld = false;
        rb.useGravity = savedGravity;
        rb.linearDamping = savedDrag;
        rb.angularDamping = savedAngularDrag;
        rb.linearVelocity += smoothedTargetVelocity * throwBoostMultiplier;

        if (playerColliders != null)
        {
            foreach (Collider pc in playerColliders)
                foreach (Collider oc in ownColliders)
                    Physics.IgnoreCollision(oc, pc, false);
        }

        cam = null;
        playerColliders = null;
    }

    public void Interact(PlayerController player)
    {
        if (!isHeld)
        {
            Pickup(player.playerCamera, player.GetComponentsInChildren<Collider>(true), player.interactionDistance);
        }
    }
}