using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameObject dialoguePanel;

    private Queue<DialogueEntry> dialogueQueue;
    private bool isDialogueActive;
    private bool isConfirmationActive; // Flag for confirmation dialogue
    private GameObject player;
    private Rigidbody2D playerRigidbody;
    private Quaternion playerOriginalRotation; // Store original rotation

    void Start()
    {
        dialogueQueue = new Queue<DialogueEntry>();
        dialoguePanel.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        playerRigidbody = player.GetComponent<Rigidbody2D>();
        playerOriginalRotation = player.transform.rotation; // Store original rotation
    }

    void Update()
    {
        if (isDialogueActive && Input.GetKeyDown(KeyCode.F))
        {
            if (isConfirmationActive)
            {
                OnConfirmationDialogueEnd();
            }
            else
            {
                DisplayNextDialogue();
            }
        }

        if (!isDialogueActive && !isConfirmationActive)
        {
            LockPlayerMovement(false);
        }
    }

    public void StartDialogue(Dialogue dialogue, System.Action onDialogueEnd = null)
    {
        dialogueQueue.Clear();
        foreach (var entry in dialogue.entries)
        {
            dialogueQueue.Enqueue(entry);
        }

        dialoguePanel.SetActive(true);
        isDialogueActive = true;
        isConfirmationActive = false; // Ensure confirmation flag is false
        LockPlayerMovement(true);
        SavePlayerRotation(); // Save player rotation before dialogue starts
        DisplayNextDialogue();
    }

    public void StartConfirmationDialogue(ConfirmationDialogue confirmationDialogue, System.Action onConfirmationEnd = null)
    {
        dialogueQueue.Clear();
        dialogueQueue.Enqueue(new DialogueEntry { speakerName = confirmationDialogue.speakerName, dialogueText = confirmationDialogue.dialogueText });

        dialoguePanel.SetActive(true);
        isDialogueActive = true;
        isConfirmationActive = true; // Set confirmation flag to true
        LockPlayerMovement(true);
        SavePlayerRotation(); // Save player rotation before dialogue starts
        DisplayNextDialogue();
    }

    public void DisplayNextDialogue()
    {
        if (dialogueQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        var dialogueEntry = dialogueQueue.Dequeue();
        nameText.text = dialogueEntry.speakerName;
        dialogueText.text = dialogueEntry.dialogueText;
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        isDialogueActive = false;
        RestorePlayerRotation(); // Restore player rotation after dialogue ends
        LockPlayerMovement(false);
    }

    void OnConfirmationDialogueEnd()
    {
        // Handle confirmation dialogue end actions here
        isConfirmationActive = false; // Reset confirmation flag
        RestorePlayerRotation(); // Restore player rotation after confirmation dialogue ends
        LockPlayerMovement(false);
    }

    public void LockPlayerMovement(bool isLocked)
    {
        playerRigidbody.constraints = isLocked ? RigidbodyConstraints2D.FreezeAll : RigidbodyConstraints2D.None;
    }

    void SavePlayerRotation()
    {
        playerOriginalRotation = player.transform.rotation;
    }

    void RestorePlayerRotation()
    {
        // Restore original z rotation
        Vector3 currentRotation = player.transform.rotation.eulerAngles;
        player.transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, playerOriginalRotation.eulerAngles.z);
    }
}
