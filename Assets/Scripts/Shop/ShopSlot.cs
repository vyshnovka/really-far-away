using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopSlot : MonoBehaviour, IPointerClickHandler
{
    [HideInInspector]
    public Clothes clothesToHold;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (clothesToHold)
        {
            ShopManager.instance.SetChoosenItem(clothesToHold);
        }
        else
        {
            ShopManager.instance.HideItemInfo();
        }
    }
}
