using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 lastPosition;
    [SerializeField]
    private GameObject triggerObject;
    Collider itemCollider;
    private Vector3 triggerPosition;

    //camera shake import


    public void Start()
    {
        lastPosition = transform.position;
        triggerPosition = triggerObject.transform.position;
    }

    public void Update()
    {

        if (transform.position == triggerPosition)
        {
            Debug.Log("It's hitting!");
            Camera.main.GetComponent<CameraShake>().ShakeCamera();
        }
    }


    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = lastPosition;
    }

}



