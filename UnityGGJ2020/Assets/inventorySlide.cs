using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventorySlide : MonoBehaviour
{
    public GameObject hiddenLocation;
    public GameObject shownLocation;

    public bool show;
    public float showSpeed;

    private Transform targetLocation;

    // Start is called before the first frame update
    void Start()
    {
        show = false;
        transform.position = hiddenLocation.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (show)
        {
            targetLocation = shownLocation.transform;
        }
        else
        {
            targetLocation = hiddenLocation.transform;
        }

        var newPos = new Vector3(targetLocation.position.x,
            targetLocation.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPos, 0.125f);
    }
}
