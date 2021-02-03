using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ConditionsManager : MonoBehaviour
{
    public static Action OPEN_DOOR;
    public static Action GET_KEY;


    [SerializeField] private LadderPickup[] door = null;
    [SerializeField] private ItemData[] items = null;
    [SerializeField] private InventorySystem inventory = null;

    #region Singleton
    public static ConditionsManager instance;

    private void Awake()
    {
        if (instance == null)
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
            if (cond.Substring(0, 4) == "HAS_")
            {
                return inventory.Contains((Tool)System.Enum.Parse(typeof(Tool), cond.Substring(4)));
            }
            switch (cond)
            {
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
            if (cond.Substring(0, 5) == "OPEN_")
            {
                door[Int32.Parse(cond.Substring(5))].openDoor();
            }
            if (cond.Substring(0, 4) == "USE_")
            {
                inventory.RemoveByEnum((Tool)System.Enum.Parse(typeof(Tool), cond.Substring(4)));
            }
            if (cond.Substring(0,4) == "GET_")
            {
                for (int i = 0; i < items.Length; i++)
                {
                    if ((cond.Substring(4).ToLower() == items[i].name.ToLower()))
                    {
                        inventory.Add(items[i]);
                        break;
                    }
                }
            }

            switch (cond)
            {

            }
        }
    }

}
