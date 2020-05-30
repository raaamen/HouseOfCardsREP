using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;

public class AudioManagerScript : MonoBehaviour
{
    public EnemyScript enemyScript;
    public AudioSource ESD;
    public bool canPlay;

    // Start is called before the first frame update
    void Start()
    {
        enemyScript = GameObject.FindGameObjectWithTag("SwordEnemy").GetComponent<EnemyScript>();
        canPlay = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyScript.curHealth <=0 && canPlay == true )
        {
            GetComponent<AudioSource>().Play();
            canPlay = false;
        }
    }
}
