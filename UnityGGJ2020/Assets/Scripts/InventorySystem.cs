using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] private GameObject inventoryUI = null;

    [SerializeField] private ItemData[] itemList = new ItemData[(int)Enum.GetValues(typeof(Tool)).Length];
    [SerializeField] private Button[] itembuttons = new Button[15];

    public static System.Action<bool> OnOpenInventory;

    public void Remove(ItemData item)
    {
        itemList[(int)item.toolAsset] = null;
        itembuttons[(int)item.toolAsset].image.sprite = null;
    }

    public void Add(ItemData item)
    {
        for (int i = 0; i < itemList.Length; i++)
        {
            if (itemList[(int)item.toolAsset] == null)
            {
                itemList[(int)item.toolAsset] = item;
            }
        }
    } 

    void Start()
    {
        inventoryUI.SetActive(false);
    }

    void Update()
    {
        /*   if (Input.GetKey("r")) {
           } */

        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            OnOpenInventory(inventoryUI.activeSelf);
        }
    }
}

public enum Tool { drill, solderingIron, wrench, adhesive, nutsNBots }; 
