using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    [SerializeField]
    private GameObject shopArea;

    [SerializeField]
    private List<ShopSlot> shopSlots;

    [SerializeField]
    private List<Clothes> shopItems = new List<Clothes>();

    [Header("Info zone for choosen item")]
    [SerializeField]
    private GameObject infoArea;
    [SerializeField]
    private Image itemImage;
    [SerializeField]
    private TextMeshProUGUI itemName;
    [SerializeField]
    private TextMeshProUGUI itemPrice;

    [Header("Sprite for the empty slot")]
    [SerializeField]
    private Sprite empty;

    [Header("Area for selling items")]
    public RectTransform sellArea;

    private Clothes choosenItem;

    void Awake()
    {
        if (instance)
        {
            Destroy(instance);
        }

        instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            shopArea.SetActive(false);
        }
    }

    void OnEnable()
    {
        FillShop();
    }

    public void SetChoosenItem(Clothes itemFromSlot)
    {
        choosenItem = itemFromSlot;

        infoArea.SetActive(true);

        itemImage.sprite = choosenItem.icon;
        itemName.text = choosenItem.description;
        itemPrice.text = choosenItem.price.ToString();
    }

    public void HideItemInfo()
    {
        infoArea.SetActive(false);
    }

    public void Buy()
    {
        if (MoneyManager.instance.GetCash() >= choosenItem.price)
        {
            shopItems.Remove(choosenItem);
            FillShop();
            ClearBoughtItem();

            InventoryManager.instance.AddToInventory(choosenItem);

            MoneyManager.instance.SetCash(-choosenItem.price);
        }
    }

    public void Sell()
    {
        Debug.Log("Sell item!");
    }

    private void FillShop()
    {
        for (int i = 0; i < shopItems.Count; i++)
        {
            shopSlots[i].clothesToHold = shopItems[i];

            shopSlots[i].gameObject.GetComponent<Image>().sprite = shopItems[i].icon;
        }
    }

    private void ClearBoughtItem()
    {
        shopSlots[shopItems.Count].clothesToHold = null;

        shopSlots[shopItems.Count].gameObject.GetComponent<Image>().sprite = empty;
    }
}
