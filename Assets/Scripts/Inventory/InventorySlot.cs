using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : Slot, IDragHandler, IEndDragHandler
{
    private Vector2 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;

        ShopManager.instance.sellArea.GetComponent<TextMeshProUGUI>().enabled = true;
        ShopManager.instance.currentlyDraggedItem = clothesToHold;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ShopManager.instance.sellArea.GetComponent<TextMeshProUGUI>().enabled = false;

        transform.position = startPos;
    }
}
