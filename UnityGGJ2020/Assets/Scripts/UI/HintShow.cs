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
    private bool isShow = false;

    private Transform temp;
    private Transform originalPos;
    private TMP_Text itemDescription;
    private Tool tempTool;
    

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

            targetItem.transform.position = Vector3.Lerp(targetItem.transform.position, tempPos, 0.2f);

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

        tempTool = draggedTool.getToolData;

        switch (tempTool)
        {
            case Tool.drill:
                targetItem.GetComponent<TMP_Text>().text = "Tool used to make holes.";
                break;
            case Tool.adhesive:
                targetItem.GetComponent<TMP_Text>().text = "some sticky material.";
                break;
            case Tool.nutsNBots:
                targetItem.GetComponent<TMP_Text>().text = "Best game out of the Ratchet and Clank Series!";
                break;
            case Tool.solderingIron:
                targetItem.GetComponent<TMP_Text>().text = "I'm not sure what this is used for.";
                break;
            case Tool.wrench:
                targetItem.GetComponent<TMP_Text>().text = "A tool so simple, even a monkey can use it!";
                break;
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isShow = false;
    }

   
}
