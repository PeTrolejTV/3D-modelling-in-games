using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class AnimatorEvent
{
    public Animator animator;
    public string triggerName = "Start";
}

[System.Serializable]
public class CompletionLight
{
    public LightController lightController;
    public bool useFlicker = true;
}

public class ObjectCounter : MonoBehaviour
{
    [Header("Counting")]
    public LayerMask countableLayer;
    public int targetCount;

    [Header("World Text")]
    public TextMeshPro displayText;
    public TextMeshPro completionText;
    public string completionMessage = "Next Area Unlocked";

    [Header("UI Text")]
    [TextArea]
    public string uiObjectiveText;

    [TextArea]
    public string uiCompletedObjectiveText;

    [TextArea]
    public string uiCompletedText = "Completed";

    [Header("Events")]
    public List<AnimatorEvent> animatorEvents = new List<AnimatorEvent>();

    [Header("Completion Lights (Optional)")]
    public List<CompletionLight> completionLights = new List<CompletionLight>();

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

    private void Start()
    {
        if (ObjectiveUI.Instance != null && !string.IsNullOrWhiteSpace(uiObjectiveText))
        {
            ObjectiveUI.Instance.SetObjectiveText(uiObjectiveText);
        }
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
        int count = _trackedRoots.Count;

        if (count >= targetCount && !_completed)
        {
            _completed = true;

            // World completion text
            if (completionText != null)
            {
                completionText.gameObject.SetActive(true);
                completionText.text = completionMessage;
            }

            // UI completion
            if (ObjectiveUI.Instance != null)
            {
                if (!string.IsNullOrWhiteSpace(uiCompletedObjectiveText))
                    ObjectiveUI.Instance.SetObjectiveText(uiCompletedObjectiveText);

                ObjectiveUI.Instance.SetProgressText(uiCompletedText);
            }

            // Animator events
            foreach (AnimatorEvent e in animatorEvents)
                if (e.animator != null && !string.IsNullOrEmpty(e.triggerName))
                    e.animator.SetTrigger(e.triggerName);

            // 🔥 Completion lights
            foreach (var cl in completionLights)
            {
                if (cl.lightController == null) continue;

                if (cl.useFlicker)
                    cl.lightController.TurnOnWithFlicker();
                else
                    cl.lightController.TurnOn();
            }
        }

        // Update counter display
        if (displayText != null)
        {
            displayText.text = _completed ? "Completed" : $"{count}/{targetCount}";
        }

        if (!_completed && ObjectiveUI.Instance != null)
        {
            ObjectiveUI.Instance.SetProgressText($"{count}/{targetCount}");
        }
    }
}