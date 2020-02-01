using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    //GameObjects


    //Vectors
    public Vector3 up;
    public Vector3 down;
    public Vector3 left;
    public Vector3 right;

    //Ints

    public int curHP;
    public int maxHP = 100;
    public int Direction;

    //Floats

    //Booleans
    public bool lookingRight  =  true;

    //Refrences
    public GameObject throwingCard;
    public Transform Target;
    public Transform shootPointRight;
    public Transform shootPointLeft;

    // Start is called before the first frame update
    void Start()
    {

        curHP = maxHP;
        Direction = 3;

//<<<<<<< HEAD:Assets/Script/PlayerScript.cs
//=======

//>>>>>>> 31d90361831fc7216bb479745a3960e6f4e4144b:Assets/PlayerScript.cs
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

 
        {
            lookingRight = true;
        }
        if (Target.transform.position.x < transform.position.x)
        {
            lookingRight = false;
        }

        // Allows the player to shoot
        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //Facing North
        //if (Direction == 1)
        //{
        //Instantiate(throwingCard, GetComponent<Transform>().position, Quaternion.identity);
        //}
        //Facing South
        //if (Direction == 2)
        //{
        //Instantiate(throwingCard, GetComponent<Transform>().position, Quaternion.identity);
        //}
        //Facing East
        //if (Direction == 3)
        //{
        //Instantiate(throwingCard, GetComponent<Transform>().position, Quaternion.identity);
        //}
        //Facing West
        //if (Direction == 4)
        //{
        //Instantiate(throwingCard, GetComponent<Transform>().position, Quaternion.identity);
        //}

        if (curHP > maxHP)
        {
            curHP = maxHP;
        }
        if (curHP <= 0)
        {
            Die();
        }

    }


        


    void Die()
    {
        //Restart
        SceneManager.LoadScene("Testt");
    }


}