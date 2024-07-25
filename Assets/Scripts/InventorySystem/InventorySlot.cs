using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Image itemImage; // Reference to the item image component
    public TextMeshProUGUI itemDescription; // Reference to the item description component
    private Item item; // The item associated with this slot

    private InventoryUI inventoryUI;

    private void Start()
    {
        inventoryUI = FindObjectOfType<InventoryUI>();
    }

    public void AddItem(Item newItem)
    {
        if (newItem == null)
        {
            Debug.Log("New item is null");
            ClearSlot();
            return;
        }
        
        item = newItem;
        if (item != null)
        {
            
            Debug.Log(item);
            
            itemImage.sprite = item.icon; // Set item icon
            itemImage.enabled = true; // Ensure the image is enabled
            itemDescription.text = item.description; // Set item description
        }
        else
        {
            ClearSlot();
        }
    }

    public void ClearSlot()
    {
        item = null;
        itemImage.sprite = null; // Clear the item icon
        itemImage.enabled = false; // Hide the image
        itemDescription.text = ""; // Clear the item description
    }

    public void OnSlotClick()
    {
        if (item != null && inventoryUI != null)
        {
            // Show item details or handle item click
            inventoryUI.ShowItemDetails(item);
            Debug.Log("Item clicked: " + item.name);
        }
    }
}