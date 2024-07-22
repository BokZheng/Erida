using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class EnemyCollision : MonoBehaviour
{
    public GameObject videoPlayerUI; // Assign the VideoPlayerUI object in the Inspector
    public VideoPlayer videoPlayer;  // Assign the VideoPlayer component in the Inspector

    private void Start()
    {
        // Ensure the video player UI is initially inactive
        videoPlayerUI.SetActive(false);

        // Subscribe to the loop point reached event to restart the scene after the video ends
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Enable the video player UI to start playing the video
            videoPlayerUI.SetActive(true);

            // Play the video
            videoPlayer.Play();
        }
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        // Restart the scene when the video finishes
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
