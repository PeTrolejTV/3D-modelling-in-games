using UnityEngine;
using System.Collections.Generic;

public class TriggerObjectToggleSession : MonoBehaviour
{
    public enum ActionType
    {
        Show,
        Hide,
        Toggle
    }

    [Header("Settings")]
    public ActionType actionType = ActionType.Show;
    public GameObject targetObject;

    [Tooltip("Unique ID per object")]
    public string id = "Level1_DoorEntrance";

    private static Dictionary<string, bool> sessionStates = new Dictionary<string, bool>();

    private void Start()
    {
        if (targetObject == null) return;

        if (sessionStates.ContainsKey(id))
        {
            targetObject.SetActive(sessionStates[id]);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (targetObject == null) return;

        bool newState = targetObject.activeSelf;

        switch (actionType)
        {
            case ActionType.Show:
                newState = true;
                break;

            case ActionType.Hide:
                newState = false;
                break;

            case ActionType.Toggle:
                newState = !targetObject.activeSelf;
                break;
        }

        targetObject.SetActive(newState);
        sessionStates[id] = newState;
    }

    public static void ClearSession()
    {
        sessionStates.Clear();
    }
}