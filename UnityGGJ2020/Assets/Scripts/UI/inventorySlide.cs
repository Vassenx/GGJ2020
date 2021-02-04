using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventorySlide : MonoBehaviour
{
    public GameObject hiddenLocation;
    public GameObject shownLocation;

    public GameObject dropHiddenLocation;
    public GameObject dropShownLocation;
    public GameObject dropSlot;

    public bool show;
    public float showSpeed;

    private Transform targetLocation;
    private Transform dropTargetLocation;

    // Start is called before the first frame update
    void Start()
    {
        show = false;
        transform.position = hiddenLocation.transform.position;
        dropSlot.transform.position = dropHiddenLocation.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (show)
        {
            targetLocation = shownLocation.transform;
            dropTargetLocation = dropShownLocation.transform;
        }
        else
        {
            targetLocation = hiddenLocation.transform;
            dropTargetLocation = dropHiddenLocation.transform;
        }

        var newPos = new Vector3(targetLocation.position.x,
            targetLocation.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, newPos, 0.125f);

        var newDropPos = new Vector3(dropTargetLocation.position.x, dropTargetLocation.transform.position.y, dropSlot.transform.position.z);
        dropSlot.transform.position = Vector3.Lerp(dropSlot.transform.position, newDropPos, 0.125f);
    }
}
