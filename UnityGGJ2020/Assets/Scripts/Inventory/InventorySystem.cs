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
        itembuttons[(int)item.toolAsset].gameObject.SetActive(false);
    }

    public void RemoveAtIndex(int i)
    {
        itemList[i] = null;
        itembuttons[i].gameObject.SetActive(false);
    }

    public void Add(ItemData item)
    {
        for (int i = 0; i < itemList.Length; i++)
        {
            if (itemList[(int)item.toolAsset] == null)
            {
                itemList[(int)item.toolAsset] = item;
                itembuttons[(int)item.toolAsset].gameObject.SetActive(true);
                itembuttons[(int)item.toolAsset].image.sprite = item.uiSprite;
            }
        }
    } 

    void Start()
    {
        //for any items preset to be automatically in inventory
        for(int i = 0; i < itemList.Length; i++)
        {
            if (itemList[i] != null)
            {
                Add(itemList[i]);
            }
            else
            {
                RemoveAtIndex(i);
            }
        }
        //inventoryUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryUI.GetComponent<inventorySlide>().show = !(inventoryUI.GetComponent<inventorySlide>().show);
            OnOpenInventory(inventoryUI.activeSelf);
        }
    }
}

public enum Tool { drill, solderingIron, wrench, adhesive, nutsNBots, keyCard }; 
