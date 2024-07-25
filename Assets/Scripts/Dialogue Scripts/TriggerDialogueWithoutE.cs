using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TriggerDialogueWithoutE : MonoBehaviour
{
    public Dialogue dialogue;
    public bool isPlayerInRange = false;
    private bool dialogueTriggered = false;

    void Update()
    {
        if (isPlayerInRange && !dialogueTriggered)
        {
            DialogueTrigger();
            dialogueTriggered = true; // Prevent triggering multiple times
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
            dialogueTriggered = false; // Reset trigger status when player exits
        }
    }

    public void DialogueTrigger()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        
    }
}
