using UnityEngine;

public static class InteractionRaycaster
{
    private const float ANGLE_OFFSET_DEGREES = 0.5f;

    public static bool TryRaycast(Transform rayOrigin, float maxDistance, out RaycastHit bestHit, out int hitCount)
    {
        Vector3 origin = rayOrigin.position;
        Vector3 forward = rayOrigin.forward;

        bestHit = default;
        hitCount = 0;
        bool anyHit = false;
        float closestDistance = maxDistance;

        System.Collections.Generic.List<RaycastHit> hits = new System.Collections.Generic.List<RaycastHit>();

        if (Physics.Raycast(origin, forward, out RaycastHit centerHit, maxDistance, ~0, QueryTriggerInteraction.Ignore))
        {
            hits.Add(centerHit);
        }

        Vector3 right = rayOrigin.right;
        Vector3 up = rayOrigin.up;

        float angleRad = ANGLE_OFFSET_DEGREES * Mathf.Deg2Rad;
        float offsetAmount = Mathf.Tan(angleRad);

        Vector3[] offsets = new Vector3[]
        {
            up * offsetAmount,
            -up * offsetAmount,
            right * offsetAmount,
            -right * offsetAmount
        };

        foreach (Vector3 offsetDir in offsets)
        {
            Vector3 direction = (forward + offsetDir).normalized;
            if (Physics.Raycast(origin, direction, out RaycastHit hit, maxDistance, ~0, QueryTriggerInteraction.Ignore))
            {
                hits.Add(hit);
            }
        }

        hitCount = hits.Count;
        foreach (RaycastHit hit in hits)
        {
            if (hit.distance < closestDistance)
            {
                closestDistance = hit.distance;
                bestHit = hit;
                anyHit = true;
            }
        }

        return anyHit;
    }
}