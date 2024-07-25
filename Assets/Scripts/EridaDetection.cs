using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EridaDetection : MonoBehaviour
{
    public float visionRange = 5f;        // Detection radius
    public LayerMask playerLayer;         // Layer for the player
    public LayerMask wallLayer;           // Layer for walls or obstacles

    private EridaAI enemyAI;
    private bool isChasing = false;

    private void Start()
    {
        enemyAI = GetComponent<EridaAI>();
    }

    private void Update()
    {
        // Check if player is within the vision range
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, visionRange, playerLayer);
        bool playerDetected = false;

        foreach (var collider in hitColliders)
        {
            if (collider.CompareTag("Player"))
            {
                // Check if player is in sight (not obstructed by walls)
                if (IsPlayerInSight(collider.transform))
                {
                    playerDetected = true;
                    break;
                }
            }
        }

        // Start or stop chasing based on detection status
        if (playerDetected && !isChasing)
        {
            Debug.Log("Player detected. Starting to chase.");
            enemyAI.StartChasing();
            isChasing = true;
        }
        else if (!playerDetected && isChasing)
        {
            Debug.Log("Player not detected. Stopping chase.");
            enemyAI.StopChasing();
            isChasing = false;
        }
    }

    private bool IsPlayerInSight(Transform player)
    {
        // // Calculate direction to player
        // Vector2 direction = (player.position - transform.position).normalized;
        //
        // // Draw the ray in the Scene view for debugging
        // Debug.DrawRay(transform.position, direction * visionRange, Color.red);
        //
        // // Perform the raycast
        // RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, visionRange, wallLayer);
        //
        // if (hit.collider != null)
        // {
        //     Debug.Log($"Raycast hit: {hit.collider.name}");
        //     if (hit.collider.CompareTag("Player"))
        //     {
        //         Debug.Log("Player detected through raycast.");
        //         return true;
        //     }
        // }
        //
        // return hit.collider == null; // Return true if no wall is hit
        
        Vector2 direction = (player.position - transform.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, visionRange, playerLayer);

        if (hit.collider == null)
            return false;

        if (hit.collider.CompareTag("Player"))
        {
            Debug.Log("found player");
            return true;
        }
        
        return false;
    }
}