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
    [SerializeField] Vector2 inventoryFrameSize;
    [SerializeField] Vector2 itemPosMod;

    void Start()
    {
        float columnPosition = inventoryFrameSize.x / inventoryColumns;
        float rowPosition = inventoryFrameSize.y / inventoryRows;

        for (int i = 0; i < inventoryColumns; i++)
        {
            for (int j = 0; j < inventoryRows; j++)
            {
                Image[] itemImages;
                ScriptableItem itemController;
                GameObject itemGO = Instantiate(itemPrefab);

                //set transform
                SetItemPosition(itemGO.transform, columnPosition * i, rowPosition * (j - 1));

                //set item controller
                Inventory.Add(itemGO);
                itemController = itemGO.GetComponent<ScriptableItem>();
                itemController.thisItem = player.Inventory[Inventory.Count - 1];

                //set image
                itemImages = itemGO.transform.GetComponentsInChildren<Image>();
                itemImages[0].sprite = itemController.thisItem.backgroundImage;
                itemImages[1].sprite = itemController.thisItem.itemImage;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //player.Inventory
    }

    void SetItemPosition(Transform itemTransform, float posX, float posY)
    {
        Rect itemRect = itemTransform.GetComponent<RectTransform>().rect;
        //itemRect.rect.Set(posX, posY, itemRect.rect.width, itemRect.rect.height);

        itemTransform.SetParent(this.transform);
        itemTransform.localPosition = new Vector3(posX * itemPosMod.x, posY * itemPosMod.y, 0);
    }
}
