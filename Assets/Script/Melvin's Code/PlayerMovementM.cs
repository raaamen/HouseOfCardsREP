using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementM : MonoBehaviour
{
    public Vector3 up, down, left, right;

    public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
        }

        if(Input.GetKey(KeyCode.W))
        {
            transform.position += up;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += left;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += down;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += right;
        }


    }
}
