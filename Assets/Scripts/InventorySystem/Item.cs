using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName = "New Item";
    public Sprite icon = null;
    public string description = "Item description here"; // Ensure this line exists
    // Add other fields as needed, e.g., stats, rarity, etc.
}