using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideDetailsOnClick : MonoBehaviour
{
    public GameObject itemDetailsPanel;

    void Update()
    {
        if (itemDetailsPanel.activeSelf && Input.GetMouseButtonDown(0))
        {
            Vector2 localMousePosition = RectTransformUtility.PixelAdjustPoint(Input.mousePosition, null, null);
            RectTransform rectTransform = itemDetailsPanel.GetComponent<RectTransform>();
            if (!RectTransformUtility.RectangleContainsScreenPoint(rectTransform, localMousePosition))
            {
                itemDetailsPanel.SetActive(false);
            }
        }
    }
}
