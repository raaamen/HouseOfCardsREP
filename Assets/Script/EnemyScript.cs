﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyScript : MonoBehaviour
{
    //Refrences
    private Transform Target;
    private PlayerScript player;

    //Floats
    public float movementSpeed;

    //Ints
    public int curHealth;
    public int maxHealth;

    private void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();

        movementSpeed = 2;
    }

    void Update()
    {
        //transform.LookAt(Player.transform);
        //transform.position = Vector2.MoveTowards( transform.position, Target.position , movementSpeed*Time.deltaTime);

        curHealth = maxHealth;

        if (curHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.Damage(3);
        }
    }
    public void TakeDamage(int damage)
    {
        curHealth -= damage;
        Debug.Log("Damage Taken");
    }
}