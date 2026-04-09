using UnityEngine;

public class DoorButton : MonoBehaviour, IInteractable
{
    public enum DoorState { Open, Closed }
    public enum ButtonAction { Open, Close, Toggle }

    [Header("References")]
    public Animator animator;

    [Header("Setup")]
    public DoorState startState = DoorState.Closed;

    [Header("Button Settings")]
    public ButtonAction action = ButtonAction.Toggle;
    public bool useOnce = false;

    private bool used = false;

    private void Start()
    {
        if (animator == null || animator.runtimeAnimatorController == null) return;

        SetState(startState == DoorState.Open);
    }

    public void Interact(PlayerController player)
    {
        if (used && useOnce) return;
        if (animator == null || animator.runtimeAnimatorController == null) return;

        bool isOpen = animator.GetBool("Open");
        bool isClosed = animator.GetBool("Close");

        switch (action)
        {
            case ButtonAction.Open:
                if (isOpen && !isClosed) return;
                OpenDoor();
                break;

            case ButtonAction.Close:
                if (isClosed && !isOpen) return;
                CloseDoor();
                break;

            case ButtonAction.Toggle:
                if (isOpen && !isClosed)
                    CloseDoor();
                else
                    OpenDoor();
                break;
        }

        used = true;
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