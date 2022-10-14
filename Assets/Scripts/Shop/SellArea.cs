using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SellArea : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(ShopManager.instance.sellArea, Input.mousePosition))
        {
            ShopManager.instance.Sell();
        }
    }
}
