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

    public void CollideWithTool(Tool tool)
    {
        toolsNeeded.Remove(tool);

        if(toolsNeeded.Count == 0)
        {
            isFixed = true;
            actSystem.UpdateAct();
            Debug.Log("I am repaired");
        }
    }
}

public enum Tool { drill, solderingIron, wrench, adhesive, nutsNBots };