using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_Score : MonoBehaviour
{
    public static int treeValue = 0;
    public string scoreType;
    private int globalScore;
    Text score;

    public float elapsedTime;
    public float timeLimit;

    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (scoreType == "Tree")
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
    }
}

