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

    public Rigidbody2D RB;
    //private Rigidbody2D rb;

    Vector2 movement;

    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // This Is The Input For The Movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {

        //This Is The Movement

        RB.MovePosition(RB.position + movement * MoveSpeed * Time.fixedDeltaTime);

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
    }
    //Flips the player on it's x-axis 
    void FlipX()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }


}
