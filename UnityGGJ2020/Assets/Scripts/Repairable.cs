using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class Repairable : MonoBehaviour
{
    public bool isFixed = false;
    public List<Tool> toolsNeeded = new List<Tool>();
    [SerializeField] private ActSystem actSystem = null;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var tool = collision.GetComponent<Item>();

        if (tool != null)
        {
            foreach(Tool toolEnum in Enum.GetValues(typeof(Tool)))
            {
                if (tool.itemData.name.Equals(tool.name))
                {
                    toolsNeeded.Remove(toolEnum);
                }
            }

            if(toolsNeeded.Count == 0)
            {
                isFixed = true;
                actSystem.UpdateAct();
                Debug.Log("I am repaired");
            }
        }
    }
}

public enum Tool { drill, solderingIron, wrench, adhesive, nutsNBots };