using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationSign : MonoBehaviour
{
    public bool show;
    public bool queued;
    public float waitCount;

    public GameObject showLocation;
    public GameObject hideLocation;

    private Transform targetLocation;

    // Start is called before the first frame update
    void Start()
    {
        waitCount = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        if (show)
        {
            targetLocation = showLocation.transform;

            if (waitCount >= 0)
            {
                waitCount -= 0.1f;
            }
            else
            {
                show = false;
                waitCount = 4f;
            }

            slide(0.125f);
        }
        else
        {
            targetLocation = hideLocation.transform;

            slide(0.2f);

            if (queued)
            {
                if (waitCount >= 0)
                {
                    waitCount -= 0.5f;
                }
                else
                {
                    queued = false;
                    show = true;
                    waitCount = 4f;
                }
            }
        }
    }

    private void slide(float speed)
    {
        var newPos = new Vector3(targetLocation.position.x, targetLocation.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPos, speed);
    }
}
