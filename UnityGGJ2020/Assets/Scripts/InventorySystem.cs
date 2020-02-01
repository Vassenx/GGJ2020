using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] private Item[] itemList = new Item[15];
    [SerializeField] private Button[] itembuttoms = new Button[15];

    [SerializeField] private Image uiWindow = null;


    public void Remove(Item item)
    {
        itemList[(int)item.itemAsset] = null;
    }

    public void Add(Item item){
            itemList[(int)item.itemAsset] = item;

    } 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     /*   if (Input.GetKey("r")) {
        } */
    }
}

    public enum I { apple, banana, carrot, dog, elephant, fuck, gorilla, help, intense, james, kelome, lagrange, macdonald,
    nomad, octopus, prakash };
