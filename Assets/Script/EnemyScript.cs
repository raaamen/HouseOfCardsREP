using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyScript : MonoBehaviour
{
    //Refrences
    private Transform Target;
    private PlayerScript player;

    //Floats
    public float movementSpeed;
    private float dazedTime;
    public float startDazedTime;

    //Ints
    public int curHealth;
    public int maxHealth;

    private void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();

        movementSpeed = 2;

        maxHealth = 10;


        curHealth = maxHealth;
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards( transform.position, Target.position , movementSpeed*Time.deltaTime);

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

        }
    }
    public void TakeDamage(int damage)
    {
        curHealth -= damage;
        dazedTime = startDazedTime;

    }
}