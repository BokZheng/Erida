using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle1onlvl1 : MonoBehaviour
{
    public Camera Maincamera;
    public Camera Puzzlecamera;
    public GameObject Mainpuzzle;
    public GameObject Player;
    public bool isPlayerinzone;

    private void Start()
    {
        Player.GetComponent<PlayerMovement>();
        Puzzlecamera.gameObject.SetActive(false);
        Mainpuzzle.SetActive(false);
    }

    private void Update()
    {
        if (isPlayerinzone && Input.GetKeyDown(KeyCode.E))
        {
            ActivatePuzzle();
            Player.SetActive(false );
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            DeactivatePuzzle();
            Player.SetActive(true );
        }
    }
    void DeactivatePuzzle()
    {
        Maincamera.gameObject.SetActive(true);
        Puzzlecamera.gameObject.SetActive(false);
        Mainpuzzle.SetActive(false );
    }

    void ActivatePuzzle()
    {
        Maincamera.gameObject.SetActive(false);
        Puzzlecamera.gameObject.SetActive(true);
        Mainpuzzle.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerinzone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerinzone = false;
        }
    }
}
