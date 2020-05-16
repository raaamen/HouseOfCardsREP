using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim1;

    //Ints
    private int Direction;

    //Floats
    public float MoveSpeed = 20f;
    //public float speed;
    private float moveX;
    private float moveY;

    //Booleans 
    private bool facingRight = true;
    private bool facingUp = true;

    public bool attacking;

    public Rigidbody2D RB;
    //private Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        attacking = false;

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(movement.x));
        animator.SetFloat("SpeedUp", Mathf.Abs(movement.y));

        // This Is The Input For The Movement
        
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        anim1.SetFloat("Speed", Mathf.Abs(movement.x));
        anim1.SetFloat("SpeedUp", Mathf.Abs(movement.y));


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
