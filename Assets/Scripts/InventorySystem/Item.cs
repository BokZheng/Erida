using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName; // Ensure this field matches what you're accessing in ShowItemDetails
    public Sprite icon;
    public string description;
}