using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingCardScript : MonoBehaviour
{
    public PlayerScript playerScript;

    public Vector3 up;
    public Vector3 down;
    public Vector3 left;
    public Vector3 right;

    public float timer;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();

        up.y = (1);
        down.y = (-1);
        left.x = (-1);
        right.x = (1);
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.deltaTime;

        if (playerScript.Direction == 1)
        {
            GetComponent<Transform>().position += up;
        }
        if (playerScript.Direction == 2)
        {
            GetComponent<Transform>().position += left;
        }
        if (playerScript.Direction == 3)
        {
            GetComponent<Transform>().position += right;
        }
        if (playerScript.Direction == 4)
        {
            GetComponent<Transform>().position += down;
        }
        if (timer >= 5)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
