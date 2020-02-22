using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public bool playerHere = false;

    public Dialogue dialogue;

    public void Update()
    {
        if (playerHere == true)
        {
            TriggerDialogue();
        }
    }

    public void TriggerDialogue()
    {
        
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerHere = true;
            Debug.Log("beep");
        }
    }

}
