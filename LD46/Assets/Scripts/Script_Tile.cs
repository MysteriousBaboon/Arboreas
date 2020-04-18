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
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 300f);
        if(hitColliders.Length != 0)

            {
            Debug.Log("Found something!");
        }
    }

    public void GenerateForest()
    {

        GameObject Tree = (GameObject)Instantiate(Resources.Load("Tree"), transform);
        Tree.transform.position = new Vector2(posX, posY);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Found something!");
        }

    }

}
