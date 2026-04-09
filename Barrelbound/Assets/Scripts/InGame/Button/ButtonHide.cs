using UnityEngine;

public class ButtonHide : MonoBehaviour, IInteractable
{
    public GameObject ObjectHide;
    private bool used = false;

    public void Interact(PlayerController player)
    {
        if (used) return;

        used = true;

        if (ObjectHide != null)
            ObjectHide.SetActive(false);
    }
}