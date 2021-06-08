using UnityEngine;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    public Item thisItem;
    public string itemName;

    public void UpdateImages()
    {
        itemName = thisItem.Name;
        Image[] itemImages;

        itemImages = transform.GetComponentsInChildren<Image>();
        itemImages[0].sprite = thisItem.backgroundImage;
        itemImages[1].sprite = thisItem.itemImage;
    }
}
