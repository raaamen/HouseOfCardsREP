﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
   /// public bool playerHere = false;

    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

}
