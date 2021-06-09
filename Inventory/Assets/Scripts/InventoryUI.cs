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
    [SerializeField] List<Sprite> ItemBackgrounds;
    [SerializeField] Vector2 inventoryFrameSize;
    [SerializeField] Vector2 itemPosMod;

    private void Awake()
    {
        player.inventoryChanged.AddListener(UpdateInventory);
    }

    void Start()
    {
        float columnPosition = inventoryFrameSize.x / inventoryColumns;
        float rowPosition = inventoryFrameSize.y / inventoryRows;

        for (int i = 0; i < inventoryColumns; i++)
        {
            for (int j = 0; j < inventoryRows; j++)
            {
                GameObject itemGO = Instantiate(itemPrefab);
                Inventory.Add(itemGO);

                //set transform
                SetItemPosition(itemGO.transform, columnPosition * i, rowPosition * (j - 1));
            }
        }
    }

    void SetItemPosition(Transform itemTransform, float posX, float posY)
    {
        Rect itemRect = itemTransform.GetComponent<RectTransform>().rect;
        //itemRect.rect.Set(posX, posY, itemRect.rect.width, itemRect.rect.height);

        itemTransform.SetParent(this.transform);
        itemTransform.localPosition = new Vector3(posX * itemPosMod.x, posY * itemPosMod.y, 0);
    }

    void UpdateInventoryItem(int index)
    {
        GameObject itemGO = Inventory[index];
        ItemController itemController;

        itemController = itemGO.GetComponent<ItemController>();
        itemController.thisItem = player.Inventory[index];
        switch (itemController.thisItem.rarity)
        {
            case Item.Rarity.common:
                itemController.thisItem.backgroundImage = ItemBackgrounds[1];
                break;
            case Item.Rarity.rare:
                itemController.thisItem.backgroundImage = ItemBackgrounds[2];
                break;
            case Item.Rarity.veryRare:
                itemController.thisItem.backgroundImage = ItemBackgrounds[3];
                break;
            case Item.Rarity.epic:
                itemController.thisItem.backgroundImage = ItemBackgrounds[4];
                break;
            case Item.Rarity.legendary:
                itemController.thisItem.backgroundImage = ItemBackgrounds[5];
                break;
            default:
                itemController.thisItem.backgroundImage = ItemBackgrounds[0];
                break;
        }

        //set image
        itemController.UpdateImages();
    }

    void UpdateInventory()
    {
        for (int i = 0; i < Inventory.Count; i++)
        {
            UpdateInventoryItem(i);
        }
    }
}
