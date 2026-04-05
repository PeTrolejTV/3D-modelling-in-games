using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    public enum TriggerMode { On, Off, Toggle, Sensor }

    [Header("References")]
    public LightController lightController;

    [Header("Trigger Settings")]
    public TriggerMode mode = TriggerMode.On;
    public string activatorTag = "Player";
    public bool oneShot = false;
    public bool useFlickerOnTurnOn = false;

    private bool _used = false;

    private void OnTriggerEnter(Collider other)
    {
        if (lightController == null) return;
        if (oneShot && _used) return;
        if (!other.CompareTag(activatorTag)) return;

        _used = true;

        switch (mode)
        {
            case TriggerMode.On:
                if (lightController.IsOn) return;
                if (useFlickerOnTurnOn) lightController.TurnOnWithFlicker();
                else lightController.TurnOn();
                break;

            case TriggerMode.Off:
                lightController.TurnOff();
                break;

            case TriggerMode.Toggle:
                if (lightController.IsOn)
                    lightController.TurnOff();
                else if (useFlickerOnTurnOn)
                    lightController.TurnOnWithFlicker();
                else
                    lightController.TurnOn();
                break;

            case TriggerMode.Sensor:
                if (lightController.IsOn) return;
                if (useFlickerOnTurnOn) lightController.TurnOnWithFlicker();
                else lightController.TurnOn();
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (lightController == null) return;
        if (mode != TriggerMode.Sensor) return;
        if (!other.CompareTag(activatorTag)) return;

        lightController.TurnOff();
    }

    public void ResetTrigger() => _used = false;
}