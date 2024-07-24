using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsConcrete : MonoBehaviour
{
    public AudioSource footstepAudioSource; // The AudioSource for footsteps
    public AudioClip[] footstepSounds; // Array of footstep sounds
    public float footstepInterval = 0.5f; // Time between footstep sounds

    private float timeSinceLastStep;

    private void Update()
    {
        // Check if the player is moving
        if (IsPlayerMoving())
        {
            timeSinceLastStep += Time.deltaTime;

            // If it's time to play a footstep sound
            if (timeSinceLastStep >= footstepInterval)
            {
                PlayFootstepSound();
                timeSinceLastStep = 0f;
            }
        }
        else
        {
            // Reset the timer if the player is not moving
            timeSinceLastStep = 0f;
        }
    }

    private bool IsPlayerMoving()
    {
        // Implement your logic to check if the player is moving.
        // For example, check if the velocity of the player is above a certain threshold.
        // Here is a basic placeholder:
        return GetComponent<Rigidbody2D>().velocity.magnitude > 0;
    }

    private void PlayFootstepSound()
    {
        if (footstepSounds.Length > 0)
        {
            // Choose a random footstep sound
            AudioClip clip = footstepSounds[Random.Range(0, footstepSounds.Length)];
            footstepAudioSource.PlayOneShot(clip);
        }
    }
}
