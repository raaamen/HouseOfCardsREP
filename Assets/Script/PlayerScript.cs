using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public AudioSource ranged;
    //GameObjects


    //Vectors
    public Vector3 Offset1;
    public Vector3 Offset2;
    public Vector3 Offset3;
    public Vector3 Offset4;

    //Ints
    public int Health;
    public int Direction;

    //Floats
    public float shootCoolDown;
    public float meleeCoolDown;
    //Booleans
    public bool lookingRight = true;
    public bool canAttack;

    //Refrences
    public GameObject throwingCard1;
    public GameObject throwingCard2;
    public GameObject throwingCard3;
    public GameObject throwingCard4;

    public Animator Anim;

    public PlayerAttack plrattack;

    public AudioSource audiosrc;
    public AudioClip melee;
    public AudioClip rangedattack;
    

    // Start is called before the first frame update
    void Start()
    {

        audiosrc = GetComponent<AudioSource>();

        Direction = 3;
        shootCoolDown = 2f;

        Offset1.y = 3;
        Offset2.x = 3;
        Offset3.x = 3;
        Offset4.y = 3;

        plrattack = GetComponent<PlayerAttack>();

        Health = 25;
    }

    void Update()
    {
        shootCoolDown += Time.deltaTime;


        if (Health <= 0)
        {
            GetComponent<SpriteRenderer>().sprite = null;
            gameObject.SetActive(false);
            
        }

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
 
        /*{
            lookingRight = true;
        }*/


        if (Input.GetKeyDown(KeyCode.J) && canAttack)
        {
            Debug.Log("Attacking anim");
            Anim.SetBool("Attacking", true);

            audiosrc.clip = melee;
            audiosrc.Play();

            if (plrattack.colliding)
            {
                Debug.Log("attacking correctly");
                Debug.Log(plrattack.collidingWith.tag);
                switch (plrattack.collidingWith.tag)
                {
                    case "Dummy":
                        StartCoroutine(plrattack.EnemyFlashRed(plrattack.collidingWith.gameObject));
                        plrattack.collidingWith.GetComponent<DummyScript>().TakeDamage(5);
                        break;
                    case "SwordEnemy":
                        plrattack.collidingWith.GetComponent<EnemyScript>().TakeDamage(5);
                        StartCoroutine(plrattack.EnemyFlashRed(plrattack.collidingWith.gameObject));
                        break;
                    case "HopEnemy":
                        plrattack.collidingWith.GetComponent<EnemyHAI>().TakeDamage(5);
                        StartCoroutine(plrattack.EnemyFlashRed(plrattack.collidingWith.gameObject));
                        break;
                    case "Jack":
                        plrattack.collidingWith.GetComponent<JackScript>().TakeDamage(5);
                        StartCoroutine(plrattack.EnemyFlashRed(plrattack.collidingWith.gameObject));
                        break;
                }
            }



            canAttack = false;
            StartCoroutine(plrattack.WaitForAttack());
        }
        else
        {
            Anim.SetBool("Attacking", false);
        }


        if (Input.GetKeyDown(KeyCode.K) && shootCoolDown >= 1)
        {
            Anim.SetBool("Throwing", true);
            GetComponent<AudioSource>().Play();
        }else
        {
            Anim.SetBool("Throwing", false);
        }


        //Allows the player to shoot
        if (Input.GetKey(KeyCode.K) && shootCoolDown >= 1)
        {
            audiosrc.clip = rangedattack;
            audiosrc.Play();
            //Facing North
            if (Direction == 1)
            {
                Instantiate(throwingCard1, GetComponent<Transform>().position + Offset1, Quaternion.identity);
            }
            //Facing South
            if (Direction == 2)
            {
                Instantiate(throwingCard2, GetComponent<Transform>().position - Offset2, Quaternion.identity);
            }
            //Facing East
            if (Direction == 3)
            {
                Instantiate(throwingCard3, GetComponent<Transform>().position + Offset3, Quaternion.identity);
            }
            //Facing West
            if (Direction == 4)
            {
                Instantiate(throwingCard4, GetComponent<Transform>().position - Offset4, Quaternion.identity);
            }
                shootCoolDown = 0;
        }
        

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("Basement");
        }



    }
    public void Damage(int dmg)
    {
        Health -= dmg;
    }
    void Die()
    {
        //Restart
        Debug.Log("You Died!");
        SceneManager.LoadScene("q");

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Sword"))
        {
            Damage(1);
        }
    }
}
