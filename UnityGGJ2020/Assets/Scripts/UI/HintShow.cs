using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class HintShow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject hintShowLocation;
    [SerializeField] private GameObject hintHiddenLocation;
    [SerializeField] private GameObject targetItem;
    [SerializeField] private DragToolButton draggedTool;
    //text pop description object, to be changed to the tool's description
    [SerializeField] private GameObject destinationText;
    private bool isShow = false;

    private Transform temp;
    private Transform originalPos;
    private TMP_Text itemDescription;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = targetItem.transform;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (isShow)
        {
            temp = targetItem.transform;
            Transform showDescriptionPosition = hintShowLocation.transform;
            var tempPos = new Vector3(showDescriptionPosition.position.x,
                                                         showDescriptionPosition.position.y,
                                                         showDescriptionPosition.position.z);

            //targetItem.transform.position = Vector3.Lerp(targetItem.transform.position, tempPos, 0.2f);
            targetItem.transform.position = tempPos;
        }
        else
        {
            targetItem.transform.position = hintHiddenLocation.transform.position;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {      
        Debug.Log("I am hovering");
        isShow = true;
        //get the description of the tool in question
        itemDescription = destinationText.GetComponent<TMP_Text>();
        //set text
        switch (draggedTool.tool)
        {
            case Tool.nutsNBots:
                itemDescription.SetText("nuts and bolts");
                break;
            case Tool.adhesive:
                itemDescription.SetText("adhesive");
                break;
            case Tool.drill:
                itemDescription.SetText("drill");
                break;
            case Tool.solderingIron:
                itemDescription.SetText("iron");
                break;
            case Tool.wrench:
                itemDescription.SetText("wrench");
                break;
            case Tool.keyCard:
                itemDescription.SetText("get access");
                break;
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isShow = false;
    }

   
}
