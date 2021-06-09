using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public List<Item> Inventory;
    [SerializeField] ItemManager ItemManager;
    public UnityEvent inventoryChanged;

    void Start()
    {
        FillInventoryWithRandoms();
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
            Inventory[i] = ItemManager.GetRandomItem();
        }
        inventoryChanged?.Invoke();
    }
}
