using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public GameObject collidingWith;

    public PlayerScript plrscrpt;

    //Ints
    public int damage;
    public int cooldown;

    //Floats
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public float attackRangeX;
    public float attackRangeY;

    

    //Transforms
    public Transform attackPos;

    //LayerMasks

    public bool colliding;
    public bool canAttack;

    // Start is called before the first frame update
    void Start()
    {
        plrscrpt = GetComponent<PlayerScript>();
        plrscrpt.canAttack = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (plrscrpt.canAttack == true)
        {
            //Now you can attack
            if (Input.GetKey(KeyCode.J) && collidingWith != null)
            {
                
                canAttack = false;
                StartCoroutine("WaitForAttack");
            }
        }
        
        



    }
    void OnDrawGizmosSelected()
    {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1));
            

    }

    public IEnumerator EnemyFlashRed(GameObject enemy)
    {
        Debug.Log("flashing red");
        if (enemy.activeInHierarchy)
        {
            enemy.GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSecondsRealtime(0.1f);
            enemy.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSecondsRealtime(0.1f);
            enemy.GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSecondsRealtime(0.1f);
            enemy.GetComponent<SpriteRenderer>().color = Color.white;
            yield return null;
            Destroy(gameObject);
            yield return null;
        }
    }
    public IEnumerator WaitForAttack()
    {
        Debug.Log("Waiting");
        
        yield return new WaitForSeconds(cooldown);
        plrscrpt.canAttack = true;

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        colliding = true;
        collidingWith = collision.gameObject;
        Debug.Log(collidingWith.name);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        colliding = false;
        collidingWith = null;
    }


}
