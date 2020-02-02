using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 lastPosition;
     
    [SerializeField] private GameObject triggerObject = null;
    [SerializeField] private InventorySystem inventorySystem = null;

    //camera shake import

    public void Start()
    {
        lastPosition = transform.position;
    }

    public void Update()
    {
        if (triggerObject != null && Vector2.Distance(transform.position, triggerObject.transform.position) <= 50f)
        {
            //Camera.main.GetComponent<CameraShake>().ShakeCamera();
            inventorySystem.Add(GetComponent<Item>().itemData);
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



