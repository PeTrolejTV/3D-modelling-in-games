using UnityEngine;

public class ObjectiveTriggerUI : MonoBehaviour
{
    public enum ActionType
    {
        EnableUI,
        DisableUI,
        ToggleUI
    }

    [Header("UI Action")]
    public ActionType actionType = ActionType.EnableUI;

    [Header("Objective Text")]
    public bool overrideObjectiveText = false;

    [TextArea]
    public string newObjectiveText;

    [Header("Progress Text")]
    public bool overrideProgressText = false;

    [TextArea]
    public string newProgressText;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (ObjectiveUI.Instance == null) return;

        switch (actionType)
        {
            case ActionType.EnableUI:
                ObjectiveUI.Instance.ShowUI();
                break;

            case ActionType.DisableUI:
                ObjectiveUI.Instance.HideUI();
                break;

            case ActionType.ToggleUI:
                ObjectiveUI.Instance.ToggleUI();
                break;
        }

        if (overrideObjectiveText)
        {
            ObjectiveUI.Instance.SetObjectiveText(newObjectiveText);
        }

        if (overrideProgressText)
        {
            ObjectiveUI.Instance.SetProgressText(newProgressText);
        }
    }
}