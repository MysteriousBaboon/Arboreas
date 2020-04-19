﻿using UnityEngine;

public class Script_GridManager : MonoBehaviour
{
    [SerializeField]
    private static int rows = 20; // Number of row for Tiles Generation
    [SerializeField]
    private static int cols = 20; // Number of Columns
    private float tileSize = 1; // Distance between each tiles

    private GameObject first_Forest;
    public Object[] tiles_Type; // Array of all type of tiles
    public static GameObject[,] tiles = new GameObject[rows, cols]; // Array of all tiles


    void Start()
    {
        GenerateTerrain(); // Generate all the tiles
    }

    private void GenerateTerrain()
    {
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                GameObject referenceTile = (GameObject)Instantiate(tiles_Type[Random.Range(0, tiles_Type.Length)]); // Randomizing the type of tile that will be generetad next
                GenerateTile(referenceTile, col, row); // Function generation 1 tile, taking the type , and the position
                Destroy(referenceTile);
            }
        }
        first_Forest = tiles[Random.Range(0,rows),Random.Range(0,cols)];
        Script_Tile script_Generate = first_Forest.GetComponent<Script_Tile>();
        script_Generate.GenerateForest();// Generate the first forest

    }

    private void GenerateTile(GameObject referenceTile, int col, int row)
    {
        GameObject tile = (GameObject)Instantiate(referenceTile, transform);

        tiles[col, row] = tile;

        float posX = col * tileSize;
        float posY = row * -tileSize;

        tile.transform.position = new Vector2(posX, posY);


        Script_Tile script = tile.GetComponent<Script_Tile>(); // Get the script of the newly generated tile 
        script.posX = col; // Give it the X and Y Pos 
        script.posY = row * -tileSize;

    }




}
