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
    public AudioSource audioSource;

    private Queue<DialogueEntry> dialogueQueue;
    private bool isDialogueActive;
    private bool isConfirmationActive;
    private GameObject player;
    private Rigidbody2D playerRigidbody;
    private float lockedZRotation;

    private System.Action onConfirmationDialogueEnd;
    private Coroutine typingCoroutine;
    private DialogueEntry currentDialogueEntry;

    void Start()
    {
        dialogueQueue = new Queue<DialogueEntry>();
        dialoguePanel.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        playerRigidbody = player.GetComponent<Rigidbody2D>();
        lockedZRotation = player.transform.rotation.eulerAngles.z;
    }

    void Update()
    {
        if (isDialogueActive)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (typingCoroutine != null)
                {
                    StopCoroutine(typingCoroutine);
                    ShowFullDialogueText();
                }
                else
                {
                    DisplayNextDialogue();
                }
            }
            else if (Input.GetKeyDown(KeyCode.R) && isConfirmationActive)
            {
                EndDialogue();
            }
        }

        LockPlayerZRotation();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueQueue.Clear();
        foreach (var entry in dialogue.entries)
        {
            dialogueQueue.Enqueue(entry);
        }

        dialoguePanel.SetActive(true);
        isDialogueActive = true;
        isConfirmationActive = false;
        LockPlayerMovement(true);
        DisplayNextDialogue();
    }

    public void StartConfirmationDialogue(ConfirmationDialogue confirmationDialogue, System.Action onConfirmationEnd)
    {
        dialogueQueue.Clear();
        dialogueQueue.Enqueue(new DialogueEntry
        {
            speakerName = confirmationDialogue.speakerName,
            dialogueText = confirmationDialogue.dialogueText,
            typingSound = confirmationDialogue.typingSound
        });

        dialoguePanel.SetActive(true);
        isDialogueActive = true;
        isConfirmationActive = true;
        LockPlayerMovement(true);
        DisplayNextDialogue();
        onConfirmationDialogueEnd = onConfirmationEnd;
    }

    private void DisplayNextDialogue()
    {
        if (dialogueQueue.Count == 0)
        {
            EndDialogue();
            if (isConfirmationActive)
            {
                onConfirmationDialogueEnd?.Invoke();
            }
            return;
        }

        currentDialogueEntry = dialogueQueue.Dequeue();
        nameText.text = currentDialogueEntry.speakerName;
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }
        typingCoroutine = StartCoroutine(TypeSentence(currentDialogueEntry.dialogueText));
    }

    private IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        for (int i = 0; i < sentence.Length; i++)
        {
            dialogueText.text += sentence[i];
            if (i % 5 == 0) // Play sound every 5 characters
            {
                PlaySound(currentDialogueEntry.typingSound);
            }
            yield return new WaitForSeconds(0.02f); // Adjust typing speed here
        }
        typingCoroutine = null;
    }

    private void ShowFullDialogueText()
    {
        dialogueText.text = currentDialogueEntry.dialogueText;
        typingCoroutine = null;
    }

    private void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        isDialogueActive = false;
        LockPlayerMovement(false);
    }

    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    private void LockPlayerMovement(bool isLocked)
    {
        if (isLocked)
        {
            playerRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else
        {
            playerRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    private void LockPlayerZRotation()
    {
        Vector3 currentRotation = player.transform.rotation.eulerAngles;
        player.transform.rotation = Quaternion.Euler(currentRotation.x, currentRotation.y, lockedZRotation);
    }
}