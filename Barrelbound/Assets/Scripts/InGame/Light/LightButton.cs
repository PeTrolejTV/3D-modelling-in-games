using UnityEngine;

public class LightButton : MonoBehaviour, IInteractable
{
    public enum ButtonMode { On, Off, Toggle }

    [Header("References")]
    public LightController lightController;

    [Header("Button Settings")]
    public ButtonMode mode = ButtonMode.Toggle;
    public bool useFlickerOnTurnOn = false;

    public void Interact(PlayerController player)
    {
        if (lightController == null)
        {
            Debug.LogWarning($"[LightButton] Missing LightController on '{gameObject.name}'.");
            return;
        }

        switch (mode)
        {
            case ButtonMode.On:
                if (lightController.IsOn) return;
                if (useFlickerOnTurnOn) lightController.TurnOnWithFlicker();
                else lightController.TurnOn();
                break;

            case ButtonMode.Off:
                if (!lightController.IsOn) return;
                lightController.TurnOff();
                break;

            case ButtonMode.Toggle:
                if (lightController.IsOn)
                    lightController.TurnOff();
                else if (useFlickerOnTurnOn)
                    lightController.TurnOnWithFlicker();
                else
                    lightController.TurnOn();
                break;
        }
    }
}