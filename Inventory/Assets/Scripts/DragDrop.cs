using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private bool isDragging = false;
    private bool isOverDropZone = false;
    public GameObject dropZone;
    private Vector2 startPosition;
    private Item item;

    void Start()
    {
        item = transform.GetComponent<ScriptableItem>().thisItem;
    }

    void Update()
    {
        if(isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {      
        dropZone = collision.gameObject;
        isOverDropZone = true;       
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverDropZone = false;
        dropZone = null;
    }

    public void StartDrag()
    {
        startPosition = transform.position;
        isDragging = true;
    }

    public void EndDrag()
    {
        isDragging = false;
        if(isOverDropZone)
        {
            ChangePosition(dropZone);
        }
        else
        {
            transform.position = startPosition;
        }
    }

    private void ChangePosition(GameObject dropZone)
    {
        Vector3 auxPos;
        auxPos = transform.position;
        transform.position = dropZone.transform.position;
        dropZone.transform.position = auxPos;
    }

    public bool IsSameType(Item target)
    {
        //if (item.type == target.type)
        //{
        //    if (item.type == Item.Type.armor)
        //    {
        //        return 
        //    }
        //}
        return true;
    }
}
