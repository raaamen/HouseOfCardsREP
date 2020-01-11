using UnityEngine;


public class LevelGenerator : MonoBehaviour
{
    public Texture2D map;

    // Start is called before the first frame update
    void Start()
    {
        generateLevel();

    }

    void generateLevel()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }
    void GenerateTile(int x, int y)
    {
        Color pixelcolor = map.GetPixel(x, y);

        if (pixelcolor.a == 0)
        {
            //ignores transparent pixels
            return;
        }

        Debug.Log("Pixel Color");
    }
}
