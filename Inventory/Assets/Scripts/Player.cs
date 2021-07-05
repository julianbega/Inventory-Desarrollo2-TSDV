using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public List<Item> Inventory;
    public ItemManager itemManager;
    public UnityEvent inventoryChanged;

    void Start()
    {
        inventoryChanged?.Invoke();
        //  FillInventoryWithRandoms();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            FillInventoryWithRandoms();
        }
    }

    void FillInventoryWithRandoms()
    {
        for (int i = 0; i < Inventory.Count; i++)
        {
            Inventory[i] = itemManager.GetRandomItem();
        }
        inventoryChanged?.Invoke();
    }
}
