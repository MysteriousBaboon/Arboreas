using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_GridManager : MonoBehaviour
{
    private int rows = 5;
    private int cols = 8;
    private float tileSize = 1;


    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateGrid()
    {
        GameObject referenceTile = (GameObject)Instantiate(Resources.Load("Grass"));
        for (int row = 0; row < rows; row++)
        {
            Debug.Log("Pr");
            for (int col = 0; col < cols; col++)
            {
                GameObject tile = (GameObject)Instantiate(referenceTile, transform);

                float posX = col * tileSize;
                float posY = row * -tileSize;

                tile.transform.position = new Vector2(posX, posY);
            }
        }

        Destroy(referenceTile);
    }
}
