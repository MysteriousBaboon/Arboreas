using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Tile : MonoBehaviour
{
    public float posX;
    public float posY;
    public bool tree = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (tree == true)
        {
            GenerateForest();
            Debug.Log(transform.position);
            tree = false;
        }
    }

    public void GenerateForest()
    {

        GameObject Tree = (GameObject)Instantiate(Resources.Load("Tree"), transform);
        Tree.transform.position = new Vector2(posX, posY);




    }
}
