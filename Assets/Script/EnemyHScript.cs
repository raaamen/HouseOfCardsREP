using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyHScript : MonoBehaviour
{
    //Refrences
    public Transform Target;
    private PlayerScript player;

    //Floats
    public float movementSpeed;
    private float dazedTime;
    public float startDazedTime;
    public float ATimer;

    //Ints
    public int curHealth;
    public int maxHealth;

    //Animatiors
    //public Animator jump;

    //Boolean
    public Boolean canAttack;

    //Vector
    public Vector3 dash;

    // Start is called before the first frame update
    void Start()
    {
        //Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        movementSpeed = 2;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        
        canAttack = false;

        //movementSpeed = 2;

        maxHealth = 5;

        dazedTime = 0;

        curHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector2.MoveTowards( transform.position, Target.position , movementSpeed*Time.deltaTime);
        
        if (canAttack == true)
        {
            ATimer += Time.deltaTime;

        }
        if (ATimer >= 2)
        {
            GetComponent<Transform>().position += dash;
            ATimer = 0;
            canAttack = false;
        }
        if (dazedTime <= 0)
        {
            movementSpeed = 2;
        }
        else
        {
            movementSpeed = 0;
            dazedTime -= Time.deltaTime;
        }


        if (curHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.Damage(5);
        }
        if (collision.CompareTag("Range"))
        {
            canAttack = true;
        }else
        {
            //jump.SetBool("Canjump", false);
        }
    }
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(1);
        }
    }
    public void TakeDamage(int damage)
    {
        curHealth -= damage;
        dazedTime = startDazedTime;
    }
}
