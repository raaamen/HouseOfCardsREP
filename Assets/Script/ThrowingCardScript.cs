using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingCardScript : MonoBehaviour
{
    public PlayerScript playerScript;
    public EnemyScript enemyScript;


    public Vector3 up;

    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        //enemyScript = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyScript>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().AddForce(up);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = null;
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy take damage");
            enemyScript.curHealth -= 5;
        }
        else if (collision.gameObject.tag=="Dummy")
        {
            Debug.Log("Dummy take damage");
            collision.gameObject.GetComponent<DummyScript>().TakeDamage(1);
            StartCoroutine(EnemyFlashRed(collision.gameObject));
        }
        else
        {
            StartCoroutine(despawnBullet(gameObject));
        }
    }
    public IEnumerator EnemyFlashRed(GameObject enemy)
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
    public IEnumerator despawnBullet(GameObject bullet)
    {
        yield return new WaitForSecondsRealtime(0.5f);
        Destroy(bullet);
        yield return null;
    }
}
