using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : Interactable
{
    // [SerializeField] private Item item;

    protected override void Interact()
    {
        base.Interact();

        //InventorySystem.instance.add(item);
    }
}
