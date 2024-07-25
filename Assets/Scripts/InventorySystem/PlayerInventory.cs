using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Inventory inventory;
    private Pickup nearbyPickup;

    void Update()
    {
        if (nearbyPickup != null && Input.GetKeyDown(KeyCode.E))
        {
            inventory.AddItem(nearbyPickup.item);
            Destroy(nearbyPickup.gameObject);  // Remove the item from the game world
            nearbyPickup = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            nearbyPickup = other.GetComponent<Pickup>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            nearbyPickup = null;
        }
    }
}
