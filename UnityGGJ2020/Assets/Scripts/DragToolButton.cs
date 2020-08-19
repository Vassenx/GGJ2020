    using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragToolButton : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private InventorySystem inventorySystem = null;
    [SerializeField] private GameObject dragClonePrefab = null;
    [SerializeField] private GameObject[] triggerObjects = null;
    [SerializeField] public Tool tool;
    private GameObject dragClone;
    
    /*
    public Tool getToolData
    {
        get => this.tool;
        set => this.tool = value;
    }
    */

    public void OnBeginDrag(PointerEventData eventData)
    {
        //inventorySystem.HideInventory();
        dragClone = Instantiate(dragClonePrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        dragClone.GetComponent<SpriteRenderer>().sprite = GetComponent<Button>().image.sprite;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (dragClone == null)
            return;

        dragClone.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        foreach(var triggerObj in triggerObjects)
        {
            if (triggerObj.GetComponent<Repairable>() != null && Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), triggerObj.transform.position) <= 50f)
            {
                //when click repairable, try to fix it if have correct tools in inventory
                triggerObj.GetComponent<Repairable>().Fix(tool);
                Destroy(dragClone);
            }
        }

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (dragClone == null)
            return;

        Destroy(dragClone);
    }


}



