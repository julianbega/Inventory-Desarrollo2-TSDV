using UnityEngine;
//using System.IO;
using System.Collections.Generic;

public class ItemManager : MonoBehaviour
{
    [SerializeField] List<Item> items;

    private void Awake()
    {
        LoadAllItems();
    }

    private void OnDestroy()
    {
        UnloadAllItems();
    }

    void LoadAllItems()
    {
        foreach (Object item in Resources.LoadAll("Items", typeof(Item)))
        {
            items.Add((Item)item);
        }
    }

    void UnloadAllItems()
    {
        foreach (Item item in items)
        {
            Resources.UnloadAsset((Object)item);
        }
    }

    public Item GetRandomItem()
    {
        Item item;
        do
        {
            item = items[Random.Range(0, items.Count - 1)];
        } while (item.rarity == Item.Rarity.empty);
        return item;
    }

}