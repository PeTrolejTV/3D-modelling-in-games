using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class AnimatorEvent
{
    public Animator animator;
    public string triggerName = "Start";
}

public class ObjectCounter : MonoBehaviour
{
    [Header("Counting")]
    public LayerMask countableLayer;
    public int targetCount = 1000;

    [Header("UI")]
    public TextMeshPro displayText;
    public TextMeshPro completionText;
    public string completionMessage = "Next Area Unlocked";

    [Header("Events")]
    public List<AnimatorEvent> animatorEvents = new List<AnimatorEvent>();

    private HashSet<GameObject> _trackedRoots = new HashSet<GameObject>();
    private Collider _triggerCollider;
    private bool _completed = false;

    private void Awake()
    {
        _triggerCollider = GetComponent<Collider>();

        if (completionText != null)
            completionText.gameObject.SetActive(false);

        UpdateDisplay();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_completed) return;
        if (!IsCountable(other)) return;
        _trackedRoots.Add(GetRoot(other));
        UpdateDisplay();
    }

    private void OnTriggerExit(Collider other)
    {
        if (_completed) return;
        if (!IsCountable(other)) return;
        GameObject root = GetRoot(other);
        if (!IsRootStillInside(root))
        {
            _trackedRoots.Remove(root);
            UpdateDisplay();
        }
    }

    private void Update()
    {
        _trackedRoots.RemoveWhere(r => r == null);
    }

    private bool IsCountable(Collider col)
    {
        return (countableLayer.value & (1 << col.gameObject.layer)) != 0;
    }

    private GameObject GetRoot(Collider col)
    {
        Rigidbody rb = col.attachedRigidbody;
        return rb != null ? rb.gameObject : col.gameObject;
    }

    private bool IsRootStillInside(GameObject root)
    {
        if (root == null) return false;
        Bounds tb = _triggerCollider.bounds;
        foreach (Collider col in root.GetComponentsInChildren<Collider>())
        {
            if (col.bounds.Intersects(tb))
                return true;
        }
        return false;
    }

    private void UpdateDisplay()
    {
        if (displayText == null) return;
        int count = _trackedRoots.Count;

        if (count >= targetCount && !_completed)
        {
            _completed = true;
            displayText.text = "Completed";

            if (completionText != null)
            {
                completionText.gameObject.SetActive(true);
                completionText.text = completionMessage;
            }

            foreach (AnimatorEvent e in animatorEvents)
                if (e.animator != null && !string.IsNullOrEmpty(e.triggerName))
                    e.animator.SetTrigger(e.triggerName);

            return;
        }

        displayText.text = $"{count}/{targetCount}";
    }
}