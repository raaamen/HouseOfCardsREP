﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    //GameObjects


    //Vectors

    //Ints

    public int curHP;
    public int maxHP = 100;
    public int Direction;

    //Floats

    //Booleans
    public bool lookingRight = true;

    //Refrences
    public GameObject throwingCard1;
    public GameObject throwingCard2;
    public GameObject throwingCard3;
    public GameObject throwingCard4;



    // Start is called before the first frame update
    void Start()
    {

        curHP = maxHP;
        Direction = 3;

        Direction = 3;
    }

    void Update()
    {
        // Allows the player to use WASD for movement.
        if (Input.GetKey(KeyCode.W))
        {
            Direction = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Direction = 4;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Direction = 2;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Direction = 3;
        }
 
        {
            lookingRight = true;
        }
        

        //Allows the player to shoot
        if (Input.GetKeyDown(KeyCode.K))
        {
            //Facing North
            if (Direction == 1)
            {
                Instantiate(throwingCard1, GetComponent<Transform>().position, Quaternion.identity);
            }
            //Facing South
            if (Direction == 2)
            {
                Instantiate(throwingCard2, GetComponent<Transform>().position, Quaternion.identity);
            }
            //Facing East
            if (Direction == 3)
            {
                Instantiate(throwingCard3, GetComponent<Transform>().position, Quaternion.identity);
            }
            //Facing West
            if (Direction == 4)
            {
                Instantiate(throwingCard4, GetComponent<Transform>().position, Quaternion.identity);
            }




        }
        if (curHP > maxHP)
        {
            curHP = maxHP;
        }
        if (curHP <= 0)
        {
            Die();
        }


    }
    public void Damage(int dmg)
    {
        curHP -= dmg;
    }
    void Die()
    {
        //Restart
        SceneManager.LoadScene("Testt");
    }
}