using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialog")]
public class Dialog : ScriptableObject
{
    public string speaker;
    public string[] sentences;
    //public Items[] conditions = { Items.HasCarrot };
}
