using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public GameObject enemyPrefab1;
    public Vector2 enemyPos1;
    public Vector2 enemyPos2;
    public Vector2 enemyPos3;
    public Vector2 enemyPos4;
    public Vector2 enemyPos5;
    public Vector2 enemyPos6;
    public float enemyTimer;
    // Start is called before the first frame update
    void Start()
    {
        enemyTimer += Time.deltaTime;
        Instantiate(enemyPrefab1, enemyPos1, Quaternion.identity);
        Instantiate(enemyPrefab1, enemyPos2, Quaternion.identity);
        Instantiate(enemyPrefab1, enemyPos3, Quaternion.identity);
        Instantiate(enemyPrefab1, enemyPos4, Quaternion.identity);
        Instantiate(enemyPrefab1, enemyPos5, Quaternion.identity);
        Instantiate(enemyPrefab1, enemyPos6, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyTimer == 3)
        {
            Instantiate(enemyPrefab1, enemyPos1, Quaternion.identity);
            Instantiate(enemyPrefab1, enemyPos2, Quaternion.identity);
            Instantiate(enemyPrefab1, enemyPos3, Quaternion.identity);
            Instantiate(enemyPrefab1, enemyPos4, Quaternion.identity);
            Instantiate(enemyPrefab1, enemyPos5, Quaternion.identity);
            Instantiate(enemyPrefab1, enemyPos6, Quaternion.identity);
            enemyTimer = 0;
        }
    }
}
