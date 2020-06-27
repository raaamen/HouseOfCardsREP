﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyHAI : MonoBehaviour
{
    public EnemyHScript enemyHScript;
    public Transform target;
    public Transform enemyGFX;
    public float speed = 400f;
    public float nextWayPointDistance = 3f;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;
    Seeker seeker;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        enemyHScript = GameObject.FindGameObjectWithTag("EnemyHS").GetComponent<EnemyHScript>();

        InvokeRepeating("UPath", 0f, .5f);
    }
    void UPath()
    {
        if(seeker.IsDone())
        seeker.StartPath(rb.position, target.position, onPathComplete);
    }
    void onPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (enemyHScript.ATimer >= 2)
        {
            speed = 1600f;
        }
        if (enemyHScript.ATimer >= 3)
        {
            speed = 400f;
            enemyHScript.ATimer = 0;
            enemyHScript.canAttack = false;
        }
        if (path == null)
        {
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        if (force.x >= 0.01f)
        {
            enemyGFX.localScale = new Vector3(-7f, 7f, 7f);
        }
        else if (force.x <= -0.01f)
        {
            enemyGFX.localScale = new Vector3(7f, 7f, 7f);
        }

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWayPointDistance)
        {
            currentWaypoint++; 
        }
    }
}
