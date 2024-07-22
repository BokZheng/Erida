using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUICOntroller : MonoBehaviour
{
    public GameObject inventoryPanel;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }
    }
}
