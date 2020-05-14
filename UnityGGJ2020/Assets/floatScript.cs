using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatScript : MonoBehaviour
{
    public GameObject sub;
    public GameObject light1;
    public GameObject light2;
    private float floatOffset = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sub.transform.localPosition = new Vector2(sub.transform.localPosition.x, Mathf.PingPong(Time.time, 10) - 10);

        light1.transform.localRotation = Quaternion.Euler(light1.transform.rotation.x, light1.transform.rotation.y, Mathf.PingPong(Time.time * 0.5f, 8) - 250);
        light2.transform.localRotation = Quaternion.Euler(light2.transform.rotation.x, light2.transform.rotation.y, Mathf.PingPong(Time.time * 0.5f, 8) - 265);
    }
}
