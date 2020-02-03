using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActSystem : MonoBehaviour
{
    [SerializeField] Repairable[] repairablesAct1 = null;
    [SerializeField] Repairable[] repairablesAct2 = null;
    public int act { get; private set; }

    //subscribe to if you want to know of act changes
    public static System.Action<int> OnActChange;

    private void Start()
    {
        act = 1;
    }

    public void UpdateAct()
    {
        var repairs = act == 1 ? repairablesAct1 : repairablesAct2;
        foreach(var repair in repairs)
        {
            if (!repair.isFixed)
            {
                return;
            }

            act++;
            OnActChange.Invoke(act);
        }
    }
}
