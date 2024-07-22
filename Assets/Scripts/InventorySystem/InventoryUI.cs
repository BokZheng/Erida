using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject detailsPanel;
    public Image detailsImage;
    public TextMeshProUGUI detailsText;
    public TextMeshProUGUI detailsDescription;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        }

        // Detect click outside the details panel
        if (Input.GetMouseButtonDown(0))
        {
            if (detailsPanel.activeSelf && !IsPointerOverUIObject())
            {
                HideItemDetails();
            }
        }
    }

    public void ShowItemDetails(Item item)
    {
        if (detailsPanel != null && detailsImage != null && detailsText != null && detailsDescription != null)
        {
            detailsPanel.SetActive(true);
            detailsImage.sprite = item.icon;
            detailsText.text = item.itemName;
            detailsDescription.text = item.description;
        }
        else
        {
            Debug.LogError("Details panel, image, text, or description not assigned in InventoryUI.");
        }
    }

    public void HideItemDetails()
    {
        if (detailsPanel != null)
        {
            detailsPanel.SetActive(false);
        }
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
