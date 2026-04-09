using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooter : MonoBehaviour
{
    [Header("Shooting Settings")]
    public GameObject projectilePrefab;
    public Camera playerCamera;
    public float shootForce = 20f;
    public float spawnDistance = 1f;

    [Header("Input")]
    public Key shootKey = Key.Space;

    void Update()
    {
        if (Keyboard.current[shootKey].wasPressedThisFrame)
            Shoot();
    }

    private void Shoot()
    {
        if (projectilePrefab == null || playerCamera == null)
            return;

        Vector3 shootDirection = playerCamera.transform.forward;
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            shootDirection = (hit.point - playerCamera.transform.position).normalized;
        }

        Vector3 spawnPosition = playerCamera.transform.position + shootDirection * spawnDistance;
        GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.LookRotation(shootDirection));
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
            rb.AddForce(shootDirection * shootForce, ForceMode.Impulse);
    }
}