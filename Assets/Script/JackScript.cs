using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JackScript : MonoBehaviour
{

    private int _health = 20;
    public int Health{
        get
        {
            return _health;
        }
        set
        {
            Debug.Log("Health before card: " + _health);
            Debug.Log("Damage taken"+value);
            _health -= value;
            Debug.Log("Health after card: "+_health);
            if (_health <= 0)
            {
                animator.SetTrigger("Death");
            }
        }
    }
    public int attemptedAttacks;

    public Transform player;

    public bool isFlipped = false;

    public Animator animator;

    private void Awake()
    {
        
        animator = GetComponent<Animator>();
    }

    public void LookAtPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Bullet")
        {
            Health -= 1;
            Destroy(collision.gameObject);
        }
        
    }
    




}
