using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUISys : MonoBehaviour
{
    public Inventory inventory;
    public GameObject slotPrefab;
    public Transform slotParent;

    void Start()
    {
        InitializeInventoryUI();
    }

    void InitializeInventoryUI()
    {
        inventory.slotPrefab = slotPrefab;
        inventory.slotParent = slotParent;
        inventory.Start();
    }
}
