using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyScript : MonoBehaviour
{
    public int hp = 5;
    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            hp -= 1;
            
        }
        if (collision.gameObject.CompareTag("Sword"))
        {
            hp -= 1;
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int damage)
    {
        hp -= damage;
        Debug.Log("Damage Taken: " + damage + " Health: " + hp);
        
        
    }
}
