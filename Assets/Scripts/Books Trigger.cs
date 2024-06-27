using UnityEngine;

public class BooksTrigger : MonoBehaviour
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
            if (spriteObject != null)
            {
                spriteObject.SetActive(false); 
            }
        }
    }
}
