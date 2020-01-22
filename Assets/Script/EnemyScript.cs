using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyScript : MonoBehaviour
{
    private Transform Target;
    public float movementSpeed;

    private void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        movementSpeed = 2;
    }

    void Update()
    {
        //transform.LookAt(Player.transform);
        transform.position = Vector2.MoveTowards( transform.position, Target.position , movementSpeed*Time.deltaTime);
    }
}