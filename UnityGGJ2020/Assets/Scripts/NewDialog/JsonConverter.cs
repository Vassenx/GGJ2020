using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonConverter
{
    public void LoadJson(string path)
    {
        using (StreamReader r = new StreamReader(path))
        {
            string rawJson = r.ReadToEnd();
            DialogTree tree = JsonUtility.FromJson<DialogTree>(rawJson);
            Debug.Log(tree.nodes[0].text);
        }
    }

    [System.Serializable]
    public struct DialogTree
    {
        public string[] conditions;
        public int act;
        public DialogNode[] nodes; 
    }


    [System.Serializable]
    public struct DialogNode
    {
        public string speaker;
        public string text;
        public string[] choices;
    }
}
