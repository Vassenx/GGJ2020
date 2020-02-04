using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragToolButton : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private InventorySystem inventorySystem = null;
    [SerializeField] private GameObject dragClonePrefab = null;
    [SerializeField] private GameObject[] triggerObjects = null;
    [SerializeField] private Tool tool = Tool.drill;
    private GameObject dragClone;

    /*Vector2 raycaster;

    private void Start()
    {
        raycaster = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }*/

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

        Debug.Log("a");
        foreach(var triggerObj in triggerObjects)
        {
            if (Vector2.Distance(Camera.main.ScreenToWorldPoint(Input.mousePosition), triggerObj.transform.position) <= 50f)
            {
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



