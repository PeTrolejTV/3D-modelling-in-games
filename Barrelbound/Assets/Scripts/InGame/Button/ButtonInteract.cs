using UnityEngine;

public class ButtonInteract : MonoBehaviour, IInteractable
{
    public Animator ButtonAnimator;

    public void Interact(PlayerController player)
    {
        if (ButtonAnimator != null)
            ButtonAnimator.SetTrigger("Pressed");
    }
}