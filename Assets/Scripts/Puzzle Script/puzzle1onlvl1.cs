using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class puzzle1onlvl1 : MonoBehaviour
{
    public Camera Maincamera;
    public Camera Puzzlecamera;
    public GameObject Mainpuzzle;

    public bool isPlayerinzone;

    private void Start()
    {
        Puzzlecamera.gameObject.SetActive(false);
        Mainpuzzle.SetActive(false);
    }

    private void Update()
    {
        if (isPlayerinzone && Input.GetKeyDown(KeyCode.E))
        {
            ActivatePuzzle();
        }
    }

    void ActivatePuzzle()
    {

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
