using UnityEngine;

public class ButtonOpen : MonoBehaviour, IInteractable
{
    public Animator OpenAnimator;

    public void Interact(PlayerController player)
    {
        if (OpenAnimator == null || OpenAnimator.runtimeAnimatorController == null) return;

        if (OpenAnimator.GetBool("Open")) return;

        OpenAnimator.SetBool("Open", true);
        OpenAnimator.SetBool("Close", false);
        OpenAnimator.SetTrigger("TrOpen");
    }
}