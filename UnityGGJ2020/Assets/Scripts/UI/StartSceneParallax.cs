using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneParallax : MonoBehaviour
{
    public GameObject[] layer;
    public Vector2 mousePos;
    private Vector2 transformHold;
    public GameObject allObjects;

    private int xoffset = 300;
    private int yoffset = 250;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        mousePos.x -= xoffset;
        mousePos.y -= yoffset;

        if (mousePos.x > xoffset)
        {
            mousePos.x = xoffset;
        }
        else if (mousePos.x < -xoffset)
        {
            mousePos.x = -xoffset;
        }

        if (mousePos.y > yoffset)
        {
            mousePos.y = yoffset;
        }
        else if (mousePos.y < -yoffset)
        {
            mousePos.y = -yoffset;
        }

        mousePos.y += Mathf.PingPong(Time.time * 150, 300);

        for (int i = 0; i < layer.Length; i++)
        {
            transformHold = layer[i].transform.position;
            transformHold.x = Mathf.Lerp(transformHold.x, mousePos.x * Mathf.Pow(i, 0.5f) * 0.05f, 0.004f);
            transformHold.y = Mathf.Lerp(transformHold.y, mousePos.y * 0.8f * Mathf.Pow(i, 0.5f) * 0.05f, 0.004f);
            layer[i].transform.localPosition = transformHold;
        }
    }
}
