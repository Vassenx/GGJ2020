using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] private GameObject inventoryUI = null;

    [SerializeField] private ItemData[] itemList = new ItemData[(int)I.SIZE];
    [SerializeField] private Button[] itembuttons = new Button[15];

    public static System.Action<bool> OnOpenInventory;

    public void Remove(ItemData item)
    {
        itemList[(int)item.itemAsset] = null;
        itembuttons[(int)item.itemAsset].image.sprite = null;
    }

    public void Add(ItemData item)
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
    nomad, octopus, prakash, SIZE };
