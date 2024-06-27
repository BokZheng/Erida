using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookShelfTrigger : MonoBehaviour
{
    public GameObject spriteObject; 
    public Sprite spriteToShow; 

    void Start()
    {
        if (spriteObject != null)
        {
            spriteObject.SetActive(false); 
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) 
        {
            Debug.Log("Player is in the box!");
            if (spriteObject != null && spriteToShow != null)
            {
                SpriteRenderer sr = spriteObject.GetComponent<SpriteRenderer>();
                if (sr != null)
                {
                    sr.sprite = spriteToShow;
                    spriteObject.SetActive(true); 
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player is out of box!");
            if (spriteObject != null)
            {
                spriteObject.SetActive(false); 
            }
        }
    }
}
