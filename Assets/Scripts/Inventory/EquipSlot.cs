using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipSlot : Slot, IDragHandler, IEndDragHandler
{
    public ClothesType type;

    private Vector2 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        ShopManager.instance.infoArea.SetActive(false);

        transform.position = Input.mousePosition;

        ShopManager.instance.currentlyDraggedItem = clothesToHold;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = startPos;
    }
}
