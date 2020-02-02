using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IDragHandler, IEndDragHandler
{
    /*
    [SerializeField]
    private bool isDragable = false;

    private GameObject toDrag;
    private Vector2 offset;

    // Start is called before the first frame update
    void Start(){ }

    private void DragCommand() {
        var inputPos = CurrentPos;
        if (isDragable)
        {
            toDrag.transform.position = inputPos + offset;
        }
        else {
            RaycastHit2D[] touches = Physics2D.RaycastAll(inputPos, inputPos, 0.5f);
            if(touches.Length >0){
                var hit = touches[0];
                if(hit.transform != )
                {
                    isDragable = true;
                    toDrag = hit.transform.gameObject;
                    offset = (Vector2)hit.transform.position - inputPos;
                    toDrag.transform.localScale = new Vector3(2f, 2f, 2f);
                }
            }
        }
    }

    private void ResetPosition() {
        isDragable = false;
        toDrag.transform.localScale = new Vector3(1f,1f,1f);
    }

    Vector2 CurrentPos{
        get
        {
            Vector2 pos;
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            return pos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            DragCommand();
        }
        else {
            if (isDragable) {
                ResetPosition();
            }

        }
    }
    */
    private Vector2 lastPosition;

    public void Start()
    {
        lastPosition = transform.position;
    }


    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = lastPosition;
    }
}



