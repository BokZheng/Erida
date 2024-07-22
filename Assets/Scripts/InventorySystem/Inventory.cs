using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public int maxSlots = 5;

    public GameObject slotPrefab;
    public Transform slotParent;

    private InventorySlot[] slots;

    public void Start()
    {
        slots = new InventorySlot[maxSlots];
        for (int i = 0; i < maxSlots; i++)
        {
            GameObject slotInstance = Instantiate(slotPrefab, slotParent);
            slots[i] = slotInstance.GetComponent<InventorySlot>();
        }
    }

    public void AddItem(Item item)
    {
        if (items.Count < maxSlots)
        {
            items.Add(item);
            UpdateUI();
        }
        else
        {
            Debug.Log("Inventory is full!");
        }
    }

    public void RemoveItem(Item item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < items.Count)
            {
                slots[i].AddItem(items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
