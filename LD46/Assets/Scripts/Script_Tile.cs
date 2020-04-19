﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Tile : MonoBehaviour
{
    public float posX; // Position X and Y of the Tile owner
    public float posY;
    public string treeState = "None"; // Does is he have a tree?
    public bool isPlanting = false; // is he actually planting?

    public float elapsedTime;
    public float timeLimit = 10f;
    public float percentageOfGrow = 0.5f;


    void Update()
    {
        if (treeState == "Alive") // Check if the tile has a tree alive 
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime > timeLimit) // Check the time
            {
                elapsedTime = 0;
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1.5f); //get every tile in range of the main tile
                for (int i = 0; i < hitColliders.Length; i++) // For every tile in range
                {
                    Script_Tile other_Script = hitColliders[i].gameObject.GetComponent<Script_Tile>();// Get the Script
                    if (other_Script.treeState == "None") // Check that it has no tree
                    {
                        other_Script.GenerateTree(false);
                    }

                }
            }
        }
    }

    public void GenerateForest() // todo Overlapsphere don't find any , fix this bug to make the beginning spawn a forest
    {
        GameObject Tree = (GameObject)Instantiate(Resources.Load("Tree"), transform); // Load a tree to the correct position
        Tree.transform.position = new Vector2(posX, posY);
        treeState = "Alive";

        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1.5f);
        for (int i = 0; i < hitColliders.Length; i++)
        {

            Script_Tile other_Script = hitColliders[i].gameObject.GetComponent<Script_Tile>();
            other_Script.GenerateTree(true);
        }

    }

    public void GenerateTree(bool over)
    {
        if (over == false) // Make it random
        {
            float a = Random.Range(0f, 1f); // Generate a random float between 0/1
            if (a < percentageOfGrow) // If the value is superior to the percentage it don't grow
            {
                GameObject Tree = (GameObject)Instantiate(Resources.Load("Tree"), transform); // load a tree to the correct position
                Tree.transform.position = new Vector2(posX, posY);
                treeState = "Alive";
            }
        }

        if (over == true) // Override the randomness
        {
            GameObject Tree = (GameObject)Instantiate(Resources.Load("Tree"), transform); // load a tree to the correct position
            Tree.transform.position = new Vector2(posX, posY);
            treeState = "Alive";
        }
    }



}
