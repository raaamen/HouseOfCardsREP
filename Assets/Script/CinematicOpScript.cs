using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CinematicOpScript : MonoBehaviour
{

    public List<Image> images;

    public Image imageHolder;

    public int i;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (i < images.Count)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                i++;
            }
        }
    }
}
