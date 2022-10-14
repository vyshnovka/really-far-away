using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [HideInInspector]
    public Clothes clothesToHold;

    private Vector2 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = startPos;
    }
}
