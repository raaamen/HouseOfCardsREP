using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed = 10f;

    public Rigidbody2D RB;

    Vector2 movement;

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
        
    }
}
