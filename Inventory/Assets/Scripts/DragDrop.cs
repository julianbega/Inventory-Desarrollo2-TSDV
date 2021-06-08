using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private bool isDragging = false;
    private bool isOverDropZone = false;
    public ItemController dropZone;
    private Vector2 startPosition;
    private ItemController itemController;

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

    private void ChangePosition(/*GameObject*/ ItemController dropZone)
    {
        /*
        Vector3 auxPos;
        auxPos = transform.position;
        transform.position = dropZone.transform.position;
        dropZone.transform.position = auxPos;
        */
        Item aux = itemController.thisItem;
        itemController.thisItem = dropZone.thisItem;
        dropZone.thisItem = aux;

        itemController.UpdateImages();
        dropZone.UpdateImages();
    }

    public bool IsSameType(Item target)
    {
        if (itemController.thisItem.type != target.type) { return false; }

        if (itemController.thisItem.type != Item.Type.armor) { return true; }

        return itemController.thisItem.subType == target.subType;
    }
}
