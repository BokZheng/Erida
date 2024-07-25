using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfirmationTriggerDialogue : MonoBehaviour
{
    public ConfirmationDialogue confirmationDialogue;
    private bool isPlayerInRange = false;
    public int scenes = 3;

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            StartConfirmationDialogue();
        }
    }

    private void StartConfirmationDialogue()
    {
        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
        if (dialogueManager != null)
        {
            dialogueManager.StartConfirmationDialogue(confirmationDialogue, OnConfirmationDialogueEnd);
        }
    }

    private void OnConfirmationDialogueEnd()
    {
        SceneManager.LoadScene(scenes); // Replace with your scene name
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}