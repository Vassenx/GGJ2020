using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneParallax : MonoBehaviour
{
    public GameObject[] layer;
    public Vector2 mousePos;
    private Vector2 transformHold;
    public GameObject allObjects;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos.x -= 460;
        mousePos.y -= 310 + Mathf.PingPong(Time.time * 200, 500);
        for(int i = 0; i < layer.Length; i++)
        {
            transformHold = layer[i].transform.position;
            transformHold.x = Mathf.Lerp(transformHold.x, mousePos.x * i * 0.01f, 0.005f);
            transformHold.y = Mathf.Lerp(transformHold.y, mousePos.y * 0.5f * i * 0.01f, 0.005f);
            layer[i].transform.position = transformHold;
        }
    }
}
