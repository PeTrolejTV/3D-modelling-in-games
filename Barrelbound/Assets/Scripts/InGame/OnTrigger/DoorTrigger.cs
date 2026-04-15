using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Collider))]
public class DoorTrigger : MonoBehaviour
{
    public enum DoorState { Open, Closed }
    public enum TriggerAction { Open, Close, Toggle, Hold }

    [Header("References")]
    public Animator animator;

    [Header("Setup")]
    public DoorState startState = DoorState.Closed;

    [Header("Trigger Settings")]
    public TriggerAction action = TriggerAction.Toggle;
    public bool triggerOnce = false;

    [Header("Detection")]
    public string playerTag = "Player";
    public bool allowObjects = false;
    public bool useCollision = false;

    private bool hasTriggered = false;
    private HashSet<Collider> objectsInside = new HashSet<Collider>();

    private void Start()
    {
        if (animator == null || animator.runtimeAnimatorController == null) return;

        SetState(startState == DoorState.Open);
    }

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
        if (animator == null || animator.runtimeAnimatorController == null) return;

        if (action == TriggerAction.Hold)
        {
            objectsInside.Add(other);

            if (objectsInside.Count == 1)
                OpenDoor();

            return;
        }

        if (triggerOnce && hasTriggered) return;

        bool isOpen = animator.GetBool("Open");
        bool isClosed = animator.GetBool("Close");

        switch (action)
        {
            case TriggerAction.Open:
                if (isOpen && !isClosed) return;
                OpenDoor();
                break;

            case TriggerAction.Close:
                if (isClosed && !isOpen) return;
                CloseDoor();
                break;

            case TriggerAction.Toggle:
                if (isOpen && !isClosed)
                    CloseDoor();
                else
                    OpenDoor();
                break;
        }

        hasTriggered = true;
    }

    private void HandleExit(Collider other)
    {
        if (action != TriggerAction.Hold) return;
        if (!IsValid(other)) return;

        objectsInside.Remove(other);

        if (objectsInside.Count == 0)
            CloseDoor();
    }

    private bool IsValid(Collider other)
    {
        if (other.CompareTag(playerTag)) return true;

        if (allowObjects && other.attachedRigidbody != null)
            return true;

        return false;
    }

    private void OpenDoor()
    {
        SetState(true);
        animator.SetTrigger("TrOpen");
    }

    private void CloseDoor()
    {
        SetState(false);
        animator.SetTrigger("TrClose");
    }

    private void SetState(bool open)
    {
        animator.SetBool("Open", open);
        animator.SetBool("Close", !open);
    }
}