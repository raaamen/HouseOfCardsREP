using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    //GameObjects


    //Vectors

    public Vector3 Offset1;
    public Vector3 Offset2;
    public Vector3 Offset3;
    public Vector3 Offset4;

    //Ints

    public int curHP;
    public int maxHP = 100;
    public int Direction;

    //Floats

    //Booleans
    public bool lookingRight = true;

    //Refrences
    public GameObject throwingCard1;
    public GameObject throwingCard2;
    public GameObject throwingCard3;
    public GameObject throwingCard4;

    public Animator Anim;
    

    // Start is called before the first frame update
    void Start()
    {

        curHP = maxHP;
        Direction = 3;

        Direction = 3;
    }

    void Update()
    {
        // Allows the player to use WASD for movement.
        if (Input.GetKey(KeyCode.W))
        {
            Direction = 1;
            //transform.localRotation = Quaternion.Euler(0, 0, 90);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Direction = 4;
            //transform.localRotation = Quaternion.Euler(0, 0, -90);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Direction = 2;
            //transform.localRotation = Quaternion.Euler(0, 0, 0);

        }
        if (Input.GetKey(KeyCode.D))
        {
            Direction = 3;
            //transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
 
        {
            lookingRight = true;
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            Anim.SetBool("Attacking", true);
        }
        else
        {
            Anim.SetBool("Attacking", false);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Anim.SetBool("Throwing", true);
        }
        else
        {
            Anim.SetBool("Throwing", false);

        }
        //Allows the player to shoot
        if (Input.GetKeyDown(KeyCode.K))
        {
            //Facing North
            if (Direction == 1)
            {
                Instantiate(throwingCard1, GetComponent<Transform>().position + Offset1, Quaternion.identity);
            }
            //Facing South
            if (Direction == 2)
            {
                Instantiate(throwingCard2, GetComponent<Transform>().position + Offset2, Quaternion.identity);
            }
            //Facing East
            if (Direction == 3)
            {
                Instantiate(throwingCard3, GetComponent<Transform>().position + Offset3, Quaternion.identity);
            }
            //Facing West
            if (Direction == 4)
            {
                Instantiate(throwingCard4, GetComponent<Transform>().position + Offset4, Quaternion.identity);
            }




        }
        if (curHP > maxHP)
        {
            curHP = maxHP;
        }
        if (curHP <= 0)
        {
            Die();
        }
        if (curHP <= 50)
        {
            Debug.Log("You are Halfway from dying");
        }
        if (curHP <= 25)
        {
            Debug.Log("You are almost dead");
        }


    }
    public void Damage(int dmg)
    {
        curHP -= dmg;
    }
    void Die()
    {
        //Restart
        Debug.Log("You Died!");
        SceneManager.LoadScene("q");

    }
}