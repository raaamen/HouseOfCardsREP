using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;

    //public Text nameText;
    public Text dialoguetext;

    public Button dialogueButton;
    public Button startDialogueButton;

    //public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        dialogueButton.interactable = false;
        startDialogueButton.interactable = true;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Start");
        //animator.SetBool("IsOpen", true);

        //nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialoguetext.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialoguetext.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        Debug.Log("End of Conversation");

        //animator.SetBool("IsOpen", false);
    }
}

