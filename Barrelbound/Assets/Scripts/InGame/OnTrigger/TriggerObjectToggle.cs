using UnityEngine;

public class TriggerObjectToggle : MonoBehaviour
{
    public enum ActionType
    {
        Show,
        Hide,
        Toggle
    }

    public ActionType actionType = ActionType.Show;
    public GameObject targetObject;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (targetObject == null) return;

        switch (actionType)
        {
            case ActionType.Show:
                targetObject.SetActive(true);
                break;

            case ActionType.Hide:
                targetObject.SetActive(false);
                break;

            case ActionType.Toggle:
                targetObject.SetActive(!targetObject.activeSelf);
                break;
        }
    }
}