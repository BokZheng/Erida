using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    private Item item;
    private InventoryUI inventoryUI;

    private void Start()
    {
        // Find the InventoryUI component in the scene
        inventoryUI = FindObjectOfType<InventoryUI>();
        if (inventoryUI == null)
        {
            Debug.LogError("InventoryUI component not found in the scene.");
        }
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
        if (icon == null)
        {
            Debug.LogError("Icon is not assigned in InventorySlot");
            return;
        }
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        item = null;
        if (icon == null)
        {
            Debug.LogError("Icon is not assigned in InventorySlot");
            return;
        }
        icon.sprite = null;
        icon.enabled = false;
    }

    public void OnSlotClick()
    {
        if (item != null)
        {
            Debug.Log("Slot clicked, showing item details: " + item.itemName);
            inventoryUI.ShowItemDetails(item);
        }
        else
        {
            Debug.Log("Slot clicked, but no item to show.");
        }
    }
}
