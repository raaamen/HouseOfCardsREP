using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CinematicOpScript : MonoBehaviour
{

    public List<Sprite> images;

    public Image imageHolder;
    public Image blackScreen;

    public LevelChanger level;

    public bool fading;

    public int i;

    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        imageHolder.sprite = images[i];
    }

    // Update is called once per frame
    void Update()
    {
        if (i < images.Count)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                level.animator.SetTrigger("FadeOut");
                StartCoroutine("wait");
                Debug.Log(i);

            }
        }

        else
        {
            SceneManager.LoadScene("Basement");
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
        i++;
        imageHolder.sprite = images[i];
    }

    

}
