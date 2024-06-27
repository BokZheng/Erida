using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerUI : MonoBehaviour
{
    public Image uiImage; 
    private bool isPlayerInside = false; 

    void Start()
    {
        if (uiImage != null)
        {
            uiImage.gameObject.SetActive(false); 
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            isPlayerInside = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            isPlayerInside = false;
            if (uiImage != null)
            {
                uiImage.gameObject.SetActive(false);
            }
        }
    }

    void Update()
    {
        if (isPlayerInside && Input.GetKeyDown(KeyCode.E))
        {
            if (uiImage != null)
            {
                uiImage.gameObject.SetActive(true); 
            }
        }
    }
}
