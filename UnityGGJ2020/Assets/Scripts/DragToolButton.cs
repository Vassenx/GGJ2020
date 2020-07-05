using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class DragToolButton : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private InventorySystem inventorySystem = null;
    [SerializeField] private GameObject dragClonePrefab = null;
    [SerializeField] private GameObject[] triggerObjects = null;
    [SerializeField] private Tool tool = Tool.drill;
    [SerializeField] private TextMeshPro hintBox = null;
    public GameObject hiddenObj;

    private GameObject dragClone;

    //float posx = transform.position.x;
    //[SerializeField] float posy;
    //[SerializeField] float posz;

    

    void Start()
    {
        transform.position = hiddenObj.transform.position;
      
    }

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

        foreach (var triggerObj in triggerObjects)
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

    public void OnMouseOver()
    {
      hintBox.transform.positio
    }

    public void OnMouseExit()
    {
        
    }

}



