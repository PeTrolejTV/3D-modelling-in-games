using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GunTrigger : MonoBehaviour
{
    public enum TriggerAction { Activate, Deactivate, Toggle, Hold }

    [System.Serializable]
    public class TriggerEntry
    {
        public Collider trigger;
        public TriggerAction action = TriggerAction.Toggle;
        public bool triggerOnce = false;

        [HideInInspector] public bool used;
        [HideInInspector] public HashSet<Collider> inside = new HashSet<Collider>();
    }

    [Header("Triggers")]
    public List<TriggerEntry> triggers = new List<TriggerEntry>();

    [Header("References")]
    public Transform barrel;
    public GameObject ammoPrefab;
    public List<Transform> shootPoints = new List<Transform>();

    [Header("Direction")]
    public Vector3 shootDirection = Vector3.forward;

    [Header("Bullet Rotation Offset")]
    public Vector3 bulletRotationOffset = new Vector3(0f, 0f, 0f);

    [Header("Detection")]
    public string playerTag = "Player";
    public bool allowObjects = false;

    [Header("Shooting")]
    public float startDelay = 2f;
    public float shootInterval = 0.5f;
    public float activeDuration = 5f;
    public float cooldownDuration = 3f;
    public float shootForce = 20f;

    [Header("Barrel Rotation")]
    public float maxSpinSpeed = 2000f;
    public float spinAcceleration = 5f;
    public float spinDeceleration = 3f;

    private bool isActive = false;
    private bool isShooting = false;

    private float currentSpinSpeed = 0f;
    private Coroutine shootRoutine;

    private void Update()
    {
        CheckTriggers();

        float targetSpeed = isShooting ? maxSpinSpeed : 0f;

        if (isShooting)
            currentSpinSpeed = Mathf.Lerp(currentSpinSpeed, targetSpeed, Time.deltaTime * spinAcceleration);
        else
            currentSpinSpeed = Mathf.Lerp(currentSpinSpeed, targetSpeed, Time.deltaTime * spinDeceleration);

        if (barrel != null)
            barrel.Rotate(Vector3.up * currentSpinSpeed * Time.deltaTime);
    }

    private void CheckTriggers()
    {
        foreach (var t in triggers)
        {
            if (t.trigger == null) continue;

            Bounds b = t.trigger.bounds;
            Collider[] hits = Physics.OverlapBox(b.center, b.extents, t.trigger.transform.rotation);

            bool hasValid = false;

            foreach (var col in hits)
            {
                if (!IsValid(col)) continue;

                hasValid = true;

                if (!t.inside.Contains(col))
                {
                    t.inside.Add(col);

                    if (t.action == TriggerAction.Hold)
                    {
                        if (t.inside.Count == 1)
                            ActivateGun();
                    }
                    else
                    {
                        if (t.triggerOnce && t.used) continue;

                        ExecuteAction(t.action);
                        t.used = true;
                    }
                }
            }

            t.inside.RemoveWhere(c => c == null || !c.bounds.Intersects(b));

            if (t.action == TriggerAction.Hold && !hasValid && t.inside.Count == 0)
                DeactivateGun();
        }
    }

    private bool IsValid(Collider other)
    {
        if (other.CompareTag(playerTag)) return true;
        if (allowObjects && other.attachedRigidbody != null) return true;
        return false;
    }

    private void ExecuteAction(TriggerAction action)
    {
        switch (action)
        {
            case TriggerAction.Activate:
                ActivateGun();
                break;
            case TriggerAction.Deactivate:
                DeactivateGun();
                break;
            case TriggerAction.Toggle:
                if (isActive) DeactivateGun();
                else ActivateGun();
                break;
        }
    }

    private void ActivateGun()
    {
        if (isActive) return;

        isActive = true;

        if (shootRoutine != null)
            StopCoroutine(shootRoutine);

        shootRoutine = StartCoroutine(ShootLoop());
    }

    private void DeactivateGun()
    {
        if (!isActive) return;

        isActive = false;
        isShooting = false;

        if (shootRoutine != null)
            StopCoroutine(shootRoutine);

        shootRoutine = null;
    }

    private IEnumerator ShootLoop()
    {
        yield return new WaitForSeconds(startDelay);

        while (isActive)
        {
            isShooting = true;

            float timer = 0f;

            while (timer < activeDuration && isActive)
            {
                ShootOnce();
                yield return new WaitForSeconds(shootInterval);
                timer += shootInterval;
            }

            isShooting = false;

            if (!isActive) yield break;

            yield return new WaitForSeconds(cooldownDuration);
        }
    }

    private void ShootOnce()
    {
        if (ammoPrefab == null || shootPoints.Count == 0) return;

        Transform point = shootPoints[Random.Range(0, shootPoints.Count)];

        Vector3 dir = barrel != null
            ? barrel.TransformDirection(shootDirection.normalized)
            : transform.TransformDirection(shootDirection.normalized);

        Quaternion rotation = Quaternion.LookRotation(dir) * Quaternion.Euler(bulletRotationOffset);

        GameObject bullet = Instantiate(ammoPrefab, point.position, rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
            rb.AddForce(dir * shootForce, ForceMode.Impulse);
    }
}