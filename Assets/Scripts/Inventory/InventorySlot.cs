using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : Slot, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Vector2 startPos;

    private Coroutine pointerOn;

    private bool isDragging = false;

    void Start()
    {
        startPos = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        isDragging = true;

        ShopManager.instance.infoArea.SetActive(false);

        transform.position = Input.mousePosition;

        ShopManager.instance.sellArea.GetComponent<TextMeshProUGUI>().enabled = true;
        ShopManager.instance.currentlyDraggedItem = clothesToHold;

        InventoryManager.instance.HidePopup();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;

        ShopManager.instance.sellArea.GetComponent<TextMeshProUGUI>().enabled = false;

        transform.position = startPos;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isDragging)
        {
            pointerOn = StartCoroutine(Utility.TimedEvent(() => 
            {
                if (clothesToHold)
                {
                    InventoryManager.instance.ShowInventoryItem(this);
                }
            }, 0.5f));
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopCoroutine(pointerOn);

        InventoryManager.instance.HidePopup();
    }
}
