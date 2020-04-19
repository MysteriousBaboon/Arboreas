using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Script_Tree : MonoBehaviour
{
    public string state = "Alive";
    public Sprite[] spriteList;
    public Button button;

    public int spriteIndex;
    public int infectionStage = 0;

    private float elapsedTime;
    public float timeLimit = 2f;
    public float percentageOfResist = 0.8f;

    void Start()
    {
        button = GetComponent<Button>();
    }

    void Update()
    {
        if (infectionStage != 0)
        {
            DetermineSpriteIndex();
        }

    }

 

    public void DetermineSpriteIndex()
    {
        if(infectionStage == -1)
        {
            spriteIndex = 6;
        }
        else
        {
            spriteIndex = infectionStage;
        }
        button.GetComponent<Image>().sprite = spriteList[spriteIndex];

    }


    public void Resist()
    {
        Debug.Log("After");

        if (Random.Range(0f, 1f) > percentageOfResist) // If the value is superior to the percentage it doesn't resist the disease
        {
            if (infectionStage == 6)
            {
                infectionStage = -1;
            }
            if (infectionStage != -1)
            {
                Debug.Log(infectionStage);
                infectionStage += 1;
            }

        }
    }

    public void HealOrCut(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("Left click");
        }
        else if (eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("Right click");
        }
    }
    public void patate(PointerEventData eventData)
    {

    }
}

