using UnityEngine;
using UnityEngine.UI;

public class ReticleController : MonoBehaviour
{
    private Image reticleImage;
    public float normalAlpha = 0.5f;
    public float highlightAlpha = 1f;

    private Camera playerCam;
    private PlayerController playerController;

    private void Awake()
    {
        reticleImage = GetComponent<Image>();
        playerCam = Camera.main;
        playerController = FindAnyObjectByType<PlayerController>();
    }

    private void Update()
    {
        if (reticleImage == null || playerCam == null || playerController == null)
            return;

        bool lookingAtInteractable = false;

        if (InteractionRaycaster.TryRaycast(playerCam.transform, playerController.interactionDistance, out RaycastHit hit, out _))
        {
            lookingAtInteractable = hit.collider.GetComponent<IInteractable>() != null || hit.collider.GetComponentInParent<IInteractable>() != null;
        }

        SetAlpha(lookingAtInteractable ? highlightAlpha : normalAlpha);
    }

    private void SetAlpha(float alpha)
    {
        Color c = reticleImage.color;
        c.a = alpha;
        reticleImage.color = c;
    }
}