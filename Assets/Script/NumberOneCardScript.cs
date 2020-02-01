using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberOneCardScript : MonoBehaviour
{
    public int curHP;
    public int maxHP;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        curHP = maxHP;

        if (curHP == 0)
        {
            Destroy(gameObject);
        }
    }
}
