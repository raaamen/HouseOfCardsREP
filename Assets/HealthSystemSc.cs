using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthSystemSc : MonoBehaviour
{



    public Sprite heartspr;

    public GameObject player;

    public PlayerScript plr;

    public Text countdownText;
    public GameObject dieText;

    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;
    public GameObject heart4;
    public GameObject heart5;

    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.Find("PlayerStill 1");
        plr = player.GetComponent<PlayerScript>();
        heart1.SetActive(true);
        heart2.SetActive(true);
        heart3.SetActive(true);
        heart4.SetActive(true);
        heart5.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (plr.Health < 20)
        {
            heart5.SetActive(false);
        }
        if (plr.Health < 15)
        {
            heart4.SetActive(false);
        }
        if (plr.Health < 10)
        {
            heart3.SetActive(false);
        }
        if (plr.Health < 5)
        {
            heart2.SetActive(false);
        }
        if (plr.Health <= 0)
        {
            heart1.SetActive(false);
            playerDie();
        }
    }
    
    
    void playerDie()
    {
        plr.gameObject.GetComponent<SpriteRenderer>().sprite = null;
        dieText.SetActive(true);

        StartCoroutine("countDownToReset");
    }

    public IEnumerator countDownToReset()
    {
        countdownText.text = "Restarting level in 3...";
        yield return new WaitForSeconds(1);
        countdownText.text = "Restarting level in 2...";
        yield return new WaitForSeconds(1);
        countdownText.text = "Restarting level in 1...";
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("FirstFloor - Copy 2");
        yield return null;
    }

}
