using UnityEngine;
using TMPro;

public class ObjectiveUI : MonoBehaviour
{
    public static ObjectiveUI Instance;

    [Header("UI")]
    public GameObject objectivePanel;
    public TextMeshProUGUI objectiveText;
    public TextMeshProUGUI progressText;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowUI()
    {
        if (objectivePanel != null)
            objectivePanel.SetActive(true);
    }

    public void HideUI()
    {
        if (objectivePanel != null)
            objectivePanel.SetActive(false);
    }

    public void ToggleUI()
    {
        if (objectivePanel != null)
            objectivePanel.SetActive(!objectivePanel.activeSelf);
    }

    public void SetObjectiveText(string text)
    {
        if (objectiveText != null)
            objectiveText.text = text;
    }

    public void SetProgressText(string text)
    {
        if (progressText != null)
            progressText.text = text;
    }

    public bool IsUIActive()
    {
        return objectivePanel != null && objectivePanel.activeSelf;
    }
}