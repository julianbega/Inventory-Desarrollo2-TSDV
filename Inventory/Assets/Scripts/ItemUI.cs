using TMPro;
using UnityEngine;

public class ItemUI : MonoBehaviour
{
    private bool isDragging = false;
    private bool isOverDropZone = false;
    public ItemController dropZone;
    private Vector2 startPosition;
    private ItemController itemController;
    public TextMeshProUGUI dataVisualizer; 

    void Update()
    {
        if(isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!isDragging) { return; }
        dropZone = collision.gameObject.GetComponent<ItemController>();
        isOverDropZone = dropZone.thisItem != null;       
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!isDragging) { return; }
        isOverDropZone = false;
        dropZone = null;
    }

    public void StartDrag()
    {
        startPosition = transform.position;
        isDragging = true;
        itemController = transform.GetComponent<ItemController>();
    }

    public void EndDrag()
    {
        isDragging = false;
        transform.position = startPosition;
        if (isOverDropZone && IsSameType(dropZone.thisItem))
        {
            ChangePosition(dropZone);
        }
    }

    private void ChangePosition(ItemController dropZone)
    {
        Item aux = itemController.thisItem;
        itemController.thisItem = dropZone.thisItem;
        dropZone.thisItem = aux;

        itemController.UpdateImages();
        dropZone.UpdateImages();
    }

    private bool IsSameType(Item target)
    {
        if (target.type == Item.Type.empty) { return true; }
        if (itemController.thisItem.type != target.type) { return false; }
        if (itemController.thisItem.type != Item.Type.armor) { return true; }

        return itemController.thisItem.subType == target.subType;
    }

    public void ShowItemData()
    {
        if (isDragging) { return; }
        itemController = transform.GetComponent<ItemController>();
        dataVisualizer.SetText(JsonUtility.ToJson(itemController.thisItem, true));
    }

    public void HideItemData()
    {
        if (isDragging) { return; }
        dataVisualizer.ClearMesh();
    }
}