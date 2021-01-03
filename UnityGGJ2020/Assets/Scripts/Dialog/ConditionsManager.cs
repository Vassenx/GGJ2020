using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ConditionsManager : MonoBehaviour
{
    public static Action OPEN_DOOR;
    public static Action GET_KEY;


    [SerializeField] private LadderPickup tutorialDoorScript = null;
    [SerializeField] private InventorySystem inventory = null;

    #region Singleton
    public static ConditionsManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    #endregion

    /* PRE-CONDITIONS */
    public bool IsSatisfied(string[] preConditions)
    {
        if (preConditions == null || preConditions.Length == 0)
            return true;

        foreach (var cond in preConditions)
        {
            switch (cond)
            {
                case "HAS_KEY":
                    return inventory.Contains(Tool.keyCard);
                case "act1":
                    //if (Act1) return true;
                    break;
                default:
                    Debug.Log("Dialog pre-condition not set correctly for condition: " + cond);
                    return false;
            }
        }
        return false;
    }

    /* POST-CONDITIONS */
    public void SatisfyConditions(string[] postConditions)
    {
        foreach (var cond in postConditions)
        {
            switch (cond)
            {
                case "OPEN_DOOR":
                    tutorialDoorScript.open = true;
                    break;
            }
        }
    }

}
