using UnityEngine;

public class ButtonShow : MonoBehaviour, IInteractable
{
    public GameObject ObjectShow;
    private bool used = false;

    public void Interact(PlayerController player)
    {
        if (used) return;

        used = true;

        if (ObjectShow != null)
            ObjectShow.SetActive(true);
    }
}