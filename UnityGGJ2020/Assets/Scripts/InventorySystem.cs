using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] private GameObject inventoryUI = null;

    [SerializeField] private Item[] itemList = new Item[15];
    [SerializeField] private Button[] itembuttons = new Button[15];

    public static System.Action<bool> OnOpenInventory;

    public void Remove(Item item)
    {
        itemList[(int)item.itemAsset] = null;
        itembuttons[(int)item.itemAsset].image.sprite = null;
    }

    public void Add(Item item)
    {
        itemList[(int)item.itemAsset] = item;
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

    public enum I { apple, banana, carrot, dog, elephant, fuck, gorilla, help, intense, james, kelome, lagrange, macdonald,
    nomad, octopus, prakash };
