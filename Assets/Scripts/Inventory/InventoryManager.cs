using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;

    [SerializeField]
    private GameObject inventoryArea;

    [SerializeField]
    private List<InventorySlot> inventorySlots;

    [SerializeField]
    private List<Clothes> inventoryItems = new List<Clothes>();

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
            LevelManager.isAbleToMove = true;

            inventoryArea.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            LevelManager.isAbleToMove = false;

            inventoryArea.SetActive(true);
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

    private void FillInventory()
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            inventorySlots[i].clothesToHold = inventoryItems[i];

            inventorySlots[i].gameObject.GetComponent<Image>().sprite = inventoryItems[i].icon;
        }
    }
}
