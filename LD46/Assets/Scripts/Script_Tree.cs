using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_Tree : MonoBehaviour
{
    public string state = "Alive";
    public Sprite[] spriteList;
    //  private SpriteRenderer spriteRenderer;
    public Button button;

    public int spriteIndex;
    public int infectionStage = 0;

    private float elapsedTime;
    public float timeLimit = 2f;
    public float percentageOfGrow = 0.2f;
    public float percentageOfResist = 0.8f;

    void Start()
    {
        button = GetComponent<Button>();
       // spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (infectionStage != 0)
        {
            DetermineSpriteIndex();
            Contaminate();
        }

        if (infectionStage > 0 && state == "Alive")
        {
            elapsedTime += Time.deltaTime;
            if(elapsedTime > timeLimit && infectionStage < 6)
            {
                elapsedTime = 0;
                infectionStage++;
            }
        }

    }

    public void DetermineSpriteIndex()
    {
        spriteIndex = infectionStage;
        button.GetComponent<Image>().sprite = spriteList[spriteIndex];
       // spriteRenderer.sprite = spriteList[spriteIndex];
    }

    public void Contaminate()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1.5f);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].tag == "Tree")
            {
                Script_Tree other_Script = hitColliders[i].gameObject.GetComponent<Script_Tree>();
                other_Script.Resist();
            }
        }
    }

    public void Resist()
    {
        Debug.Log("f");
        float a = Random.Range(0f, 1f); // Generate a random float between 0/1

        if (a > percentageOfResist) // If the value is superior to the percentage it doesn't resist the disease
        {

            if (infectionStage == 0)
            {
                infectionStage = 1;
            }
        }
    }


}
