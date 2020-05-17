using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;

public static class JsonConverter
{
    public static List<DialogTree> allDialogTrees;

    public static void LoadJson(string path)
    {
        allDialogTrees = new List<DialogTree>();

        using (StreamReader r = new StreamReader(path))
        {
            string rawJson = r.ReadToEnd();
            DialogTree tree = JsonUtility.FromJson<DialogTree>(rawJson);
            tree.nodes.OrderBy(node => node.id); //make sure the nodes are in order (by height)
            allDialogTrees.Add(tree);
        }
    }

}

/// <summary>
/// <list type="bullet">
/// <item> <description> conditions = PRE conditions </description> </item>
/// <item> <description> colliderName = obj with the speaker component on it to collide with to start the dialog </description> </item>
/// </list>
/// 
/// Be careful, Unity treats serializable non-monobehavior classes like structs.
/// This means do not write dialogNodeObj == null, instead try dialogNodeObj.choices == null.
/// </summary>
[System.Serializable]
public class DialogTree
{
    public string[] preconditions;
    //priority: first tree to be picked if pre-conditions are satisified. 
    //the first one should have priority 0
    public int priority;
    public bool repeatable;
    public string colliderName;
    public DialogNode[] nodes;
}

[System.Serializable]
public struct DialogNode
{
    public int id;
    public string speaker;
    public string text;
    public int[] choices;
}
