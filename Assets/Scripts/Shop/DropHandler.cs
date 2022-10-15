using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropHandler : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (RectTransformUtility.RectangleContainsScreenPoint(ShopManager.instance.sellArea, Input.mousePosition))
        {
            ShopManager.instance.Sell();
        }
        else if (RectTransformUtility.RectangleContainsScreenPoint(InventoryManager.instance.unequipArea, Input.mousePosition))
        {
            if (InventoryManager.instance.CheckIfEquipped())
            {
                InventoryManager.instance.Unequip();
            }
        }
        else
        {
            if (ShopManager.instance.currentlyDraggedItem)
            {
                for (int i = 0; i < InventoryManager.instance.equipSlots.Count; i++)
                {
                    if (RectTransformUtility.RectangleContainsScreenPoint(InventoryManager.instance.equipSlots[i], Input.mousePosition))
                    {
                        if (InventoryManager.instance.equippedSlots[i].type == ShopManager.instance.currentlyDraggedItem.type)
                        {
                            InventoryManager.instance.Equip(i);
                        }
                    }
                }
            }
        }

        ShopManager.instance.currentlyDraggedItem = null;
    }
}
