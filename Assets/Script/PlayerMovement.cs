using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 10f;
    //public float speed;
    private float moveX;
    private float moveY;

    private bool facingRight = true;
    private bool facingUp = true;

    public bool attacking;

    public Rigidbody2D RB;
    //private Rigidbody2D rb;

    Vector2 movement;

    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        attacking = false;

    }

    // Update is called once per frame
    void Update()
    {
        // This Is The Input For The Movement
        
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        if (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.K))
        {
            attacking = true;
        }else
        {
            attacking = false;
        }
    }
    private void FixedUpdate()
    {

        //This Is The Movement
        if (attacking == false)
        {
            RB.MovePosition(RB.position + movement * MoveSpeed * Time.fixedDeltaTime);
        }
        /*
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        Debug.Log(moveX + moveY);
        rb.velocity = new Vector3(moveX, moveY * speed, rb.velocity.y);
        */       

        if (facingRight == false && movement.x > 0)
        {
            FlipX();
        }
        else if (facingRight == true && movement.x < 0)
        {
            FlipX();
        }
        /*
        if (facingUp == false && movement.y > 0)
        {
            FlipY();
        }
        else if (facingUp == true && movement.y < 0)
        {
            FlipY();
        }
        */
    }
    //Flips the player on it's x-axis 
    void FlipX()
    {
        facingRight = !facingRight;
        Vector3 ScalerX = transform.localScale;
        ScalerX.x *= -1;
        transform.localScale = ScalerX;
    }
    /*
    void FlipY()
    {
        facingUp = !facingUp;
        Vector3 ScalerY = transform.localScale;
        ScalerY.y *= -1;
        transform.localScale = ScalerY;
    }
    */


}
