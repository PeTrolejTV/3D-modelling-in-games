using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Collider))]
public class LightTrigger : MonoBehaviour
{
    public enum TriggerMode { On, Off, Toggle, Hold }

    [Header("References")]
    public LightController lightController;

    [Header("Trigger Settings")]
    public TriggerMode mode = TriggerMode.On;
    public bool oneShot = false;
    public bool useFlickerOnTurnOn = false;

    [Header("Detection")]
    public string activatorTag = "Player";
    public bool allowObjects = false;
    public bool useCollision = false;

    private bool hasTriggered = false;

    private HashSet<Collider> objectsInside = new HashSet<Collider>();

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
        if (lightController == null) return;

        if (mode == TriggerMode.Hold)
        {
            objectsInside.Add(other);

            if (objectsInside.Count == 1)
                TurnOn();

            return;
        }

        if (oneShot && hasTriggered) return;

        switch (mode)
        {
            case TriggerMode.On:
                if (lightController.IsOn) return;
                TurnOn();
                break;

            case TriggerMode.Off:
                if (!lightController.IsOn) return;
                lightController.TurnOff();
                break;

            case TriggerMode.Toggle:
                if (lightController.IsOn)
                    lightController.TurnOff();
                else
                    TurnOn();
                break;
        }

        hasTriggered = true;
    }

    private void HandleExit(Collider other)
    {
        if (mode != TriggerMode.Hold) return;
        if (!IsValid(other)) return;
        if (lightController == null) return;

        objectsInside.Remove(other);

        if (objectsInside.Count == 0)
            lightController.TurnOff();
    }

    private bool IsValid(Collider other)
    {
        if (other.CompareTag(activatorTag)) return true;

        if (allowObjects && other.attachedRigidbody != null)
            return true;

        return false;
    }

    private void TurnOn()
    {
        if (useFlickerOnTurnOn)
            lightController.TurnOnWithFlicker();
        else
            lightController.TurnOn();
    }

    public void ResetTrigger()
    {
        hasTriggered = false;
    }
}