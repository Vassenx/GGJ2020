using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialog")]
public class Dialog : ScriptableObject
{
    public Choice[] choices;
}
