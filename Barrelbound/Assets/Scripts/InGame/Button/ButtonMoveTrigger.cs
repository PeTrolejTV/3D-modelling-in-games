using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class MovableObject
{
    public Transform target;
    public float minY;
    public float maxY;
    public float moveDuration = 2f;
}

public class ButtonMoveTrigger : MonoBehaviour, IInteractable
{
    public enum ActionType { Rise, Fall, Toggle }

    [Header("Button Settings")]
    public ActionType action = ActionType.Toggle;
    public bool useOnce = false;
    public float objectDelay = 1f;

    [Header("Objects")]
    public List<MovableObject> objects = new List<MovableObject>();

    private bool used = false;
    private Dictionary<Transform, Coroutine> _activeCoroutines = new Dictionary<Transform, Coroutine>();

    public void Interact(PlayerController player)
    {
        if (used && useOnce) return;
        if (objects == null || objects.Count == 0) return;

        StartCoroutine(MoveObjectsRoutine());
        used = true;
    }

    private IEnumerator MoveObjectsRoutine()
    {
        foreach (var obj in objects)
        {
            if (obj.target == null) continue;

            float startY = obj.target.position.y;
            float targetY = GetTargetY(obj, startY);

            if (_activeCoroutines.ContainsKey(obj.target))
                StopCoroutine(_activeCoroutines[obj.target]);

            _activeCoroutines[obj.target] = StartCoroutine(MoveObject(obj.target, startY, targetY, obj.moveDuration));
            yield return new WaitForSeconds(objectDelay);
        }
    }

    private float GetTargetY(MovableObject obj, float currentY)
    {
        switch (action)
        {
            case ActionType.Rise: return obj.maxY;
            case ActionType.Fall: return obj.minY;
            case ActionType.Toggle: return Mathf.Approximately(currentY, obj.minY) ? obj.maxY : obj.minY;
        }
        return currentY;
    }

    private IEnumerator MoveObject(Transform target, float startY, float targetY, float duration)
    {
        float elapsed = 0f;
        Vector3 startPos = target.position;
        Vector3 endPos = new Vector3(startPos.x, targetY, startPos.z);

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);
            target.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }

        target.position = endPos;
        _activeCoroutines.Remove(target);
    }
}