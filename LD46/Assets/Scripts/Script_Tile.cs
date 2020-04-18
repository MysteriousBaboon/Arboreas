using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Tile : MonoBehaviour
{
    public float posX;
    public float posY;
    public bool tree = false;
    public bool isPlanting = false;

    public float elapsedTime;
    public float timeLimit = 10f;
    public float percentageOfGrow = 0.5f;


    void Update()
    {

        if (isPlanting == true) // Check if the tree should be planting a tree
        {
            if (tree == false)
            {
                GenerateTree();
                Debug.Log(transform.position);
                tree = true;
            }
            else
            {
                elapsedTime += Time.deltaTime;
                if (elapsedTime > timeLimit)
                {
                    Debug.Log(timeLimit);
                    elapsedTime = 0;

                    Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1.5f);
                    for (int i = 0; i < hitColliders.Length; i++)
                    {
                        float a = Random.Range(0f, 1f);
                        if (a < percentageOfGrow)
                        {
                            Debug.Log(a);
                            Script_Tile other_Script = hitColliders[i].gameObject.GetComponent<Script_Tile>();
                            other_Script.isPlanting = true;
                        }
                    }

                }
            }
        }


  
    }

    public void GenerateForest()
    {
        GameObject Tree = (GameObject)Instantiate(Resources.Load("Tree"), transform);
        Tree.transform.position = new Vector2(posX, posY);
        tree = true;
        isPlanting = true;
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1.5f);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            Script_Tile other_Script = hitColliders[i].gameObject.GetComponent<Script_Tile>();
            other_Script.isPlanting = true;
        }

    }

    public void GenerateTree()
    {
        GameObject Tree = (GameObject)Instantiate(Resources.Load("Tree"), transform);
        Tree.transform.position = new Vector2(posX, posY);
    }



}
