using UnityEngine;

public class ButtonClose : MonoBehaviour, IInteractable
{
    public Animator CloseAnimator;

    private bool used = false;

    public void Interact(PlayerController player)
    {
        if (used) return;

        used = true;

        if (CloseAnimator != null)
            CloseAnimator.SetBool("Close", true);
            CloseAnimator.SetTrigger("TrClose");
    }
}