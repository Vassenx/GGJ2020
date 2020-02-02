using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Choice")]
//For example "A: I agree. What should we do?" is a choice with two sentences
public class Choice : ScriptableObject
{
    public string[] sentences;
    public Choice[] children;
    //public Item[] conditions;
}
