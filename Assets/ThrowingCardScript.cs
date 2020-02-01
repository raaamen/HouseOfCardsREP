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

        up.y = (5);
        down.y = (-5);
        left.x = (-5);
        right.x = (5);
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
}
