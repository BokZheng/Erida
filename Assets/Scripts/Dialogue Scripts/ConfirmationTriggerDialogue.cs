using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfirmationTriggerDialogue : MonoBehaviour
{
    public ConfirmationDialogue confirmationDialogue;
    private bool isPlayerInRange = false;

    void Update()
    {
        // Check for player interaction to trigger confirmation dialogue
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            StartConfirmationDialogue();
        }
    }

    void StartConfirmationDialogue()
    {
        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
        if (dialogueManager != null)
        {
            dialogueManager.LockPlayerMovement(true);
            dialogueManager.StartConfirmationDialogue(confirmationDialogue, OnConfirmationDialogueEnd);
        }
    }

    void OnConfirmationDialogueEnd()
    {
        // Proceed to next scene if confirmed
        SceneManager.LoadScene("NextSceneName"); // Replace "NextSceneName" with your scene name
        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
        if (dialogueManager != null)
        {
            dialogueManager.LockPlayerMovement(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}