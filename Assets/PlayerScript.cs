using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public Vector3 up;
    public Vector3 down;
    public Vector3 left;
    public Vector3 right;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Transform>().position + up;
        }


    }

 }

