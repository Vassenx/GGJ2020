using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HintShow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject hintShowLocation;
    [SerializeField] private GameObject hintHiddenLocation;
    [SerializeField] private GameObject targetItem;
    private bool isShow = false;

    private Transform temp;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {      
        Debug.Log("I am hovering");
        isShow = true;
              
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        targetItem.transform.position = hintShowLocation.transform.position;
    }

    public void Slide(float speed)
    {
        temp = targetItem.transform;
        Transform showDescriptionPosition = hintShowLocation.transform;
        var tempPos = new Vector3(showDescriptionPosition.position.x,
                                                     showDescriptionPosition.position.y,
                                                     showDescriptionPosition.position.z);

        targetItem.transform.position = Vector3.Lerp(targetItem.transform.position, tempPos, 0.2f);
    }
}
