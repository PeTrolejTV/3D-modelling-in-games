using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Collider))]
public class PressurePlate : MonoBehaviour
{
    [Header("Settings")]
    public string playerTag = "Player";
    public bool requireRigidbody = true;
    public bool useCollision = false;

    [Header("Animation")]
    public Animator animator;

    private HashSet<Collider> objectsOnPlate = new HashSet<Collider>();

    public bool IsPressed => objectsOnPlate.Count > 0;

    public bool Pressed { get; private set; }
    public bool Released { get; private set; }

    private void OnTriggerEnter(Collider other)
    {
        if (useCollision) return;
        HandleEnter(other);
    }

    private void OnTriggerExit(Collider other)
    {
        if (useCollision) return;
        HandleExit(other);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!useCollision) return;
        HandleEnter(collision.collider);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (!useCollision) return;
        HandleExit(collision.collider);
    }

    private void HandleEnter(Collider other)
    {
        if (!IsValid(other)) return;

        objectsOnPlate.Add(other);
        UpdateState();
    }

    private void HandleExit(Collider other)
    {
        if (!IsValid(other)) return;

        objectsOnPlate.Remove(other);
        UpdateState();
    }

    private bool IsValid(Collider other)
    {
        if (other.CompareTag(playerTag)) return true;

        if (requireRigidbody && other.attachedRigidbody != null)
            return true;

        return false;
    }

    private void UpdateState()
    {
        bool currentlyPressed = IsPressed;

        Pressed = currentlyPressed;
        Released = !currentlyPressed;

        if (animator != null)
        {
            animator.SetBool("Pressed", currentlyPressed);
            animator.SetBool("Released", !currentlyPressed);

            if (currentlyPressed)
                animator.SetTrigger("TrPress");
            else
                animator.SetTrigger("TrRelease");
        }
    }
}