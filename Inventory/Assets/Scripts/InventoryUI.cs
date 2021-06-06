using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Player player;
    public int inventoryColumns;
    public int inventoryRows;
    public GameObject itemPrefab;
    public List<GameObject> Inventory;

    void Start()
    {
        for (int i = 0; i < inventoryColumns; i++)
        {
            for (int j = 0; j < inventoryRows; j++)
            {
                Image[] itemImages;
                Inventory.Add(Instantiate(itemPrefab));
                Inventory[Inventory.Count-1].transform.SetParent(this.transform);
                itemImages = Inventory[Inventory.Count - 1].transform.GetComponentsInChildren<Image>();// 
                itemImages[0].sprite = player.Inventory[Inventory.Count - 1].backgroundImage;
                itemImages[1].sprite = player.Inventory[Inventory.Count - 1].itemImage;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //player.Inventory
    }
}
