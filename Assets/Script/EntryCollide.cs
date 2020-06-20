using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryCollide : MonoBehaviour
{

    public bool isTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isTriggered==false)
        {
            Debug.Log("Entry triggered");
            GetComponentInParent<Animator>().SetTrigger("CanStart");
            isTriggered = true;
        }
        
    }
}
