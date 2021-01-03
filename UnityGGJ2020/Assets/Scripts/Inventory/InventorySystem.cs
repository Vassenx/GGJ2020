using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] private GameObject inventoryUI = null;

    [SerializeField] private ItemData[] itemList = new ItemData[9];
    [SerializeField] private Button[] itembuttons = new Button[15];

    public static System.Action<bool> OnOpenInventory;

    public void Remove(ItemData item)
    {
        for (int i = 0; i < itemList.Length; i++)
        {
            if(itemList[i] == item)
            {
                //set element of the array to null once.
                itemList[i] = null;
                itembuttons[i].gameObject.SetActive(false);
                break;
            }
        
        }
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
            if (itemList[i] == null)
            {
                //add element to the array
                itemList[i] = item;
                itembuttons[i].gameObject.SetActive(true);
                itembuttons[i].image.sprite = item.uiSprite;
                break;
            }
            else
            {
                //no more space in the inventory
                Debug.Log("No more space in the inventory.");
            }
        }
    }

    public bool Contains(Tool tool)
    {
        for (int i = 0; i < itemList.Length; i++)
        {
            if (itemList[i] != null && itemList[i].toolAsset == tool)
            {
                return true;
            }
        }
        return false;
    }

    public void RemoveByEnum(Tool tool)
    {
        for (int i = 0; i < itemList.Length; i++)
        {
            //check if given tool exists
            if (itemList[i] != null && itemList[i].toolAsset == tool)
            {
                itemList[i] = null;
                itembuttons[i].gameObject.SetActive(false);
                break;
            }
        }
    }

    void Start()
    {
        //for any items preset to be automatically in inventory
        /*
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
        */
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
