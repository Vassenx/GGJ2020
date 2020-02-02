using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragToolButton : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private InventorySystem inventorySystem = null;
    [SerializeField] private GameObject dragClonePrefab = null;
    [SerializeField] private Tool tool;
    private GameObject dragClone;

    public void OnBeginDrag(PointerEventData eventData)
    {
        //inventorySystem.HideInventory();
        dragClone = Instantiate(dragClonePrefab, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
        dragClone.GetComponent<SpriteRenderer>().sprite = GetComponent<Button>().image.sprite;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //TODO:

        /*if (Vector2.Distance(dragClone.transform.position, repairable.transform.position) <= 50f)
        {
            repairable.CollideWithTool(tool);
        }*/
        dragClone.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Destroy(dragClone);
    }
}



