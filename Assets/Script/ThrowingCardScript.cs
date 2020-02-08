﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingCardScript : MonoBehaviour
{
    public PlayerScript playerScript;
    public EnemyScript enemyScript;


    public Vector3 up;
    /*public Vector3 down;
    public Vector3 left;
    public Vector3 right;*/

    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        enemyScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyScript>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        GetComponent<Rigidbody2D>().AddForce(up);
        //GetComponent<Transform>().position += up;
        
        if (timer >= 1)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyScript.curHealth -= 5;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            
        }
    }
}
