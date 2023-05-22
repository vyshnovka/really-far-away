using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.U2D.Animation;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    [SerializeField]
    private GameObject inventoryArea;

    [SerializeField]
    private List<InventorySlot> inventorySlots;
    private List<Clothes> inventoryItems = new List<Clothes>();

    public List<EquipSlot> equippedSlots;
    private List<Clothes> equippedItems = new List<Clothes>();

    [Header("Sprite for the empty slot")]
    [SerializeField]
    private Sprite empty;

    [Header("Places to store clothes")]
    [SerializeField]
    private List<SpriteLibrary> spriteLibrary;

    [Header("Inventory area for unequipping")]
    public RectTransform unequipArea;

    [Header("All equiping slots' gameobjects")]
    public List<RectTransform> equipSlotsRect;

    [Header("Pop-up for onPointerEnter")]
    [SerializeField]
    private GameObject popup;
    [SerializeField]
    private Image itemIcon;
    [SerializeField]
    private TextMeshProUGUI itemName;
    [SerializeField]
    private TextMeshProUGUI itemPrice;

    [SerializeField]
    [Range(-100, 100)]
    private float offsetX = 48f;
    [SerializeField]
    [Range(-100, 100)]
    private float offsetY = 48f;

    [Header("Referenced interactable")]
    [SerializeField]
    private Interactable interactable;

    void Awake()
    {
        if (instance)
        {
            Destroy(instance);
        }

        instance = this;
    }

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            equippedItems.Add(null);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LevelManager.isAbleToMove = true;

            inventoryArea.SetActive(false);

            HidePopup();

            if (CheckIfAllSet())
            {
                LevelManager.isWearingFullSet = true;
            }
            else
            {
                LevelManager.isWearingFullSet = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (LevelManager.hasTouchedEndline)
            {
                DialogueManager.instance.StartMonologue(interactable.dialogue, interactable);
            }
            else
            {
                LevelManager.isAbleToMove = false;

                inventoryArea.SetActive(true);
            }
        }
    }

    void OnEnable()
    {
        FillInventory();
    }

    public void AddToInventory(Clothes newItem)
    {
        inventoryItems.Add(newItem);

        FillInventory();
    }

    public void RemoveFromInventory(Clothes oldItem)
    {
        inventoryItems.Remove(oldItem);

        FillInventory();
        ClearInventoryItem();
    }

    private void FillInventory()
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            inventorySlots[i].clothesToHold = inventoryItems[i];

            inventorySlots[i].gameObject.GetComponent<Image>().sprite = inventoryItems[i].icon;
        }
    }

    public void Equip(int position)
    {
        inventoryItems.Remove(ShopManager.instance.currentlyDraggedItem);
        equippedSlots[position].clothesToHold = ShopManager.instance.currentlyDraggedItem;
        equippedItems[position] = ShopManager.instance.currentlyDraggedItem;

        equippedSlots[position].GetComponent<Image>().sprite = ShopManager.instance.currentlyDraggedItem.icon;

        spriteLibrary[position].spriteLibraryAsset = ShopManager.instance.currentlyDraggedItem.sprites;

        ShopManager.instance.currentlyDraggedItem = null;

        FillInventory();
        ClearInventoryItem();
    }

    public void Unequip()
    {
        int position = equippedItems.FindIndex(a => a == ShopManager.instance.currentlyDraggedItem);

        AddToInventory(equippedItems[position]);

        spriteLibrary[position].spriteLibraryAsset = null;
        spriteLibrary[position].gameObject.GetComponent<SpriteRenderer>().sprite = null;

        equippedSlots[position].gameObject.GetComponent<Image>().sprite = empty;
        equippedSlots[position].clothesToHold = null;

        equippedItems[position] = null;

        ShopManager.instance.currentlyDraggedItem = null;

        FillInventory();
    }

    public bool CheckIfEquipped()
    {
        for (int i = 0; i < equippedItems.Count; i++)
        {
            if (equippedSlots[i].gameObject.GetComponent<Image>().sprite != empty)
            {
                if (equippedItems.Contains(ShopManager.instance.currentlyDraggedItem))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private void ClearInventoryItem()
    {
        inventorySlots[inventoryItems.Count].clothesToHold = null;

        inventorySlots[inventoryItems.Count].gameObject.GetComponent<Image>().sprite = empty;
    }

    private bool CheckIfAllSet()
    {
        foreach (var item in equippedItems)
        {
            if (!item)
            {
                return false;
            }
        }

        return true;
    }

    public void ShowInventoryItem(InventorySlot slot)
    {
        itemIcon.sprite = slot.clothesToHold.icon;
        itemName.text = slot.clothesToHold.description;
        itemPrice.text = slot.clothesToHold.price.ToString();

        popup.transform.position = new Vector2(slot.transform.position.x + offsetX, slot.transform.position.y + offsetY);

        popup.SetActive(true);
    }

    public void HidePopup()
    {
        popup.SetActive(false);
    }
}
