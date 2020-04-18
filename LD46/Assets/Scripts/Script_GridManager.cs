using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_GridManager : MonoBehaviour
{
    private int rows = 5; // Number of row for Tiles Generation
    private int cols = 5; // Number of Columns
    private float tileSize = 1; // Distance between each tiles
    public Object[] tiles_Type; // Array of all type of tiles
    private List<GameObject> tiles_List = new List<GameObject>(); // List of all tiles generated

    void Start()
    {
        GenerateTerrain(); // Generate all the tiles
        GenerateForest(); // Generate the first forest
    }



    private void GenerateTerrain()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                GameObject referenceTile = (GameObject)Instantiate(tiles_Type[Random.Range(0, tiles_Type.Length)]); // Randomizing the type of tile that will be generetad next
                GenerateTile(referenceTile, col, row); // Function generation 1 tile, taking the type , and the position
            }
        }

    }

    private void GenerateTile(GameObject referenceTile,int col, int row)
    {
        GameObject tile = (GameObject)Instantiate(referenceTile, transform);
        

        float posX = col * tileSize;
        float posY = row * -tileSize;

        tile.transform.position = new Vector2(posX, posY);


        Script_Tile Script = tile.GetComponent<Script_Tile>(); // Get the script of the newly generated tile 
        Script.posX = col; // Give it the X and Y Pos 
        Script.posY = row * -tileSize;


    }

    private void GenerateForest()
    {
              
    }
}
