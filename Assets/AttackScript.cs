using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    //Refrences
    public Collider2D attackTrigger;

    //Ints
    public int Direction;

    //Floats
    public float attackTimer;
    public float attackCoolDown;

    //Booleans
    private bool attacking;
    // Start is called before the first frame update
    void Start()
    {
        attacking = false;
        attackTimer = 0;
        attackCoolDown = 0.3f;
        attackTrigger.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Allows the player to melee
        if (Input.GetKeyDown(KeyCode.J) && !attacking)
        {
            attacking = true;
            attackTimer = attackCoolDown;

            attackTrigger.enabled = true;
        }
        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
            }
        }

    }
}
