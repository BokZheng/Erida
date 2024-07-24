using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicSound : MonoBehaviour
{
    public AudioSource enemyAudioSource; // The AudioSource on the enemy
    public Transform player; // The player's transform
    public float maxDistance = 10f; // The distance at which the sound is at max volume
    public float minVolume = 0.1f; // Minimum volume when the player is far

    private void Update()
    {
        // Calculate the distance between the player and the enemy
        float distance = Vector3.Distance(player.position, transform.position);

        // Calculate the volume based on distance
        float volume = Mathf.Clamp01(1 - (distance / maxDistance));
        volume = Mathf.Max(volume, minVolume); // Ensure the volume does not go below the minimum

        // Apply the volume to the AudioSource
        enemyAudioSource.volume = volume;
    }
}