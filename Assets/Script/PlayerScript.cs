using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject throwingCard;
    public Vector3 up;
    public Vector3 down;
    public Vector3 left;
    public Vector3 right;
    public int HP;
    public int Direction;

    // Start is called before the first frame update
    void Start()
    {
        HP = 4;
        Direction = 3;

    }

    // Update is called once per frame
    void Update()
    {
        // Allows the player to use WASD for movement.
        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Transform>().position += up;
            Direction = 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<Transform>().position += down;
            Direction = 4;
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Transform>().position += left;
            Direction = 2;
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Transform>().position += right;
            Direction = 3;
        }
        // Allows the player to shoot
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Direction == 1)
            {
                Instantiate(throwingCard);
            }
            if (Direction == 2)
            {
                Instantiate(throwingCard);
            }
            if (Direction == 3)
            {
                Instantiate(throwingCard);
            }
            if (Direction == 4)
            {
                Instantiate(throwingCard);
            }


        }

    }

}

