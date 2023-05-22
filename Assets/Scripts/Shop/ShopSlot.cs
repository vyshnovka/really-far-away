using UnityEngine.EventSystems;

public class ShopSlot : Slot, IPointerClickHandler
{
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
