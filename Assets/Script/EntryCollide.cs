using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EntryCollide : MonoBehaviour
{

    public GameObject flowchart;
    public bool isTriggered = false;
    public GameObject jack;
    public GameObject player;
    public GameObject barrier;


    public Camera mainCam;
    public Camera viewCam;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && isTriggered==false)
        {
            mainCam.gameObject.SetActive(false);
            viewCam.gameObject.SetActive(true);
            flowchart.SetActive(true);
            Debug.Log("Entry triggered");
            player.gameObject.GetComponent<PlayerScript>().canMove = false;
            isTriggered = true;
        }
        
    }

    public void moveJackToPos()
    {
        Vector3 newvec = new Vector3(156.2f, 1.4f, 0.837536f);
        jack.transform.position = newvec;
    }

    public void stopFlowchart()
    {
        mainCam.gameObject.SetActive(true);
        viewCam.gameObject.SetActive(false);
        barrier.SetActive(false);
        player.gameObject.GetComponent<PlayerScript>().canMove = true;
        flowchart.SetActive(false);
        GetComponentInParent<Animator>().SetTrigger("CanStart");
        gameObject.SetActive(false);
    }

    public void loadEnd()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("EndScene");
    }

}
