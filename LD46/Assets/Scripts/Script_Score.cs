using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Script_Score : MonoBehaviour
{
    public static int treeValue = 0;
    public string scoreType;
    private int globalScore;
    Text score;

    public GameObject Patate;
    public float elapsedTime;
    public float timeLimit;

    private bool gameIsOver = false;

    void Start()
    {

        score = GetComponent<Text>();
    }

  

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (scoreType == "Tree" && gameIsOver == false )
        {
            GameObject[] trees = GameObject.FindGameObjectsWithTag("Tree");
            treeValue = trees.Length;
            score.text = "Trees: " + treeValue;
        }
        if (scoreType == "Score" && elapsedTime > timeLimit)
        {
            elapsedTime = 0;
            GameObject[] trees = GameObject.FindGameObjectsWithTag("Tree");
            treeValue = 0;
            for (int i = 0; i < trees.Length; i++) // For every tile in range
            {
                Script_Tree other_Script = trees[i].gameObject.GetComponent<Script_Tree>();// Get the Script
                if (other_Script.state == "Alive")
                {
                    treeValue += 2;
                }
            }

            globalScore += treeValue;
            score.text = globalScore.ToString();

        }
        LookForGameOver();
    }

    void LookForGameOver()
    {
       GameObject[] go = GameObject.FindGameObjectsWithTag("Tree");
        for (int i = 0; i < go.Length; i++)
        {
            Script_Tree script_t = go[i].gameObject.GetComponent<Script_Tree>();// Get the Script

            if (script_t.state == "Alive")
                {
                return;
                }
        }
        GoToGameOver();

    }

    void GoToGameOver()
    {
        if (scoreType == "Score")
        {
            DontDestroyOnLoad(transform.root.gameObject);
            SceneManager.LoadScene("Scene_GameOver");

        }

        if (scoreType == "Tree")
        {
            gameIsOver = true;
        }

    }
}

