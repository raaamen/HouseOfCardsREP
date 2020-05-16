using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueReader : MonoBehaviour
{
    //the text file
    public TextAsset txtFile;

    //list of every line of dialogue as a string
    public List<string> dialogueList;

    //keeps track of what line dialogue is at, used for accessing dialoguelist
    public int i;

    // Start is called before the first frame update
    void Start()
    {
        var lines = txtFile.text.Split("\n"[0]);
        foreach (var obj in lines)
        {
            dialogueList.Add(obj);
        }
        StartCoroutine("instructText");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //CODE ABOUT COMING INTO CONTACT WITH CHARACTER

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rule Card")
        {
            beginDialogue();
        }
    }

    public void beginDialogue()
    {
        //dialogue box becomes visible
        //text scrolls, reads in from dialogueList
        //goes in order of the list pretty much, all of the lines are sorted chronologically
        //depending on the character speaking, the portrait will change sprite to either the player or the other convo person
        //access MC and RC in dialogue to see who is speaking
    }

}
