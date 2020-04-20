using UnityEngine;

public class Script_Tile : MonoBehaviour
{
    public float posX; // Position X and Y of the Tile owner
    public float posY;
    public Sprite[] spriteList;
    public GameObject goTree; // Does is he have a tree?

    public float elapsedTime;
    public float timeLimit;
    public float percentageOfGrow = 0.5f;

    private SpriteRenderer spriteR;


    void Start()
    {
        int random = Random.Range(0, spriteList.Length);
        spriteR = gameObject.GetComponent<SpriteRenderer>();
        spriteR.sprite = spriteList[random];
    }

    void Update()
    {
        if (goTree != null) // Check if the tile has a tree 
        {
                elapsedTime += Time.deltaTime;

                if (elapsedTime > timeLimit) // Check the time
                {
                    elapsedTime = 0;

                    Script_Tree goTree_Script = goTree.GetComponent<Script_Tree>();

                    Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1.5f); //get every tile in range of the main tile

                    for (int i = 0; i < hitColliders.Length; i++) // For every tile in range
                    {

                        if (goTree_Script.state == "Alive")
                        {
                            if (hitColliders[i].tag == "Ground") // Check for grow
                            {
                                Script_Tile other_Script = hitColliders[i].gameObject.GetComponent<Script_Tile>();// Get the Script
                                if (other_Script.goTree == null) // Check that it has no tree
                                {
                                    other_Script.GenerateTree(false);
                                }
                            }
                        }



                        if (goTree_Script.infectionStage > 0)
                        {
                            if (hitColliders[i].tag == "Tree")
                            {
                                Script_Tree other_Script = hitColliders[i].gameObject.GetComponent<Script_Tree>();// Get the Script
                                if (other_Script.infectionStage >= 0) // Check that it has no tree
                                {
                                    other_Script.Resist();
                                }
                            }
                        }
                    }
            }
        }
    }

    public void GenerateForest() // todo Overlapsphere don't find any , fix this bug to make the beginning spawn a forest
    {
        GameObject Tree = (GameObject)Instantiate(Resources.Load("Tree"), transform); // Load a tree to the correct position
        Tree.transform.position = new Vector2(posX + 1f, posY + 1f);
        goTree = Tree;

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
            if (Random.Range(0f, 1f) < percentageOfGrow) // If the value is superior to the percentage it don't grow
            {
                GameObject Tree = (GameObject)Instantiate(Resources.Load("Tree"), transform); // load a tree to the correct position
                Tree.transform.position = new Vector2(posX, posY+1);
                goTree = Tree;
            }
        }

        if (over == true) // Override the randomness
        {
            GameObject Tree = (GameObject)Instantiate(Resources.Load("Tree"), transform); // load a tree to the correct position
            Tree.transform.position = new Vector2(posX + 1f, posY + 1f);
            goTree = Tree;
        }
    }



}
 