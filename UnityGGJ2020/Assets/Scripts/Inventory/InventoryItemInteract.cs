using UnityEngine;

public class InventoryItemInteract : ItemInteract
{
    [SerializeField] private InventorySystem inventorySystem = null;

    public override void ClickInteract()
    {
        base.ClickInteract();
        //click item to add to inventory
        inventorySystem.Add(item.itemData);
        Destroy(gameObject);
    }
}
