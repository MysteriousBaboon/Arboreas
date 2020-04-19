using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_Score : MonoBehaviour
{
    public static int treeValue = 0;
    Text tree;

    void Start()
    {
        tree = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] trees = GameObject.FindGameObjectsWithTag("Tree");
        treeValue = trees.Length;
        tree.text = "Trees: " + treeValue;
    }
}

