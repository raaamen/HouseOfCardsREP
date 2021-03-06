﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //Ints
    public int damage;

    //Floats
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public float attackRangeX;
    public float attackRangeY;

    //Transforms
    public Transform attackPos;

    //LayerMasks
    public LayerMask whatIsEnemies;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            //Now you can attack
            if (Input.GetKey(KeyCode.J))
            {
                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, whatIsEnemies);
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<DummyScript>().TakeDamage(damage);
                }

            }

            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
        
    }
    void OnDrawGizmosSelected()
    {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1));
            

    }
}
