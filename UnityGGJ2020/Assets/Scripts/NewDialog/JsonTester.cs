using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonTester : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            JsonConverter jsonConverter = new JsonConverter();
            jsonConverter.LoadJson("Assets/jtest.json");
        }
    }
}
