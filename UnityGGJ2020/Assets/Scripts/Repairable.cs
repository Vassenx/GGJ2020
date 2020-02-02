using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class Repairable : MonoBehaviour
{
    public bool isFixed = false;
    public Tool[] toolsNeeded;
    [SerializeField] private ActSystem actSystem = null;
    private int curIndex = 0;

    public void Fix(Tool tool)
    {
        if(!isFixed && toolsNeeded[curIndex] == tool)
        {
            if(curIndex == toolsNeeded.Length)
            {
                isFixed = true;
                actSystem.UpdateAct(); //check if this finishes the act
                Debug.Log("I am repaired");
            }
        }
    }
}