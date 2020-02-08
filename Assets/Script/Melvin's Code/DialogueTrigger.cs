using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
   

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        FindObjectOfType<DialogueManager>().dialogueButton.interactable = true;
        FindObjectOfType<DialogueManager>().startDialogueButton.interactable = false;
    }
}
