using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text DialogueText;

    public DialogueTrigger DT;

    public Animator animator;

    public Queue<string> sentences;


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        DT = GameObject.FindGameObjectWithTag("RuleCard").GetComponent<DialogueTrigger>();
    }

    private void Update()
    {
        
           // animator.SetBool("isOpen", true);
        
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);
        nameText.text = dialogue.name;
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
        }

        string sentence = sentences.Dequeue();
        DialogueText.text = sentence;
    }
    void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        Debug.Log("End Dialogue");
    }
}
