using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Script_Tree : MonoBehaviour, IPointerClickHandler
{
    public string state = "Alive";
    public Sprite[] spriteList;
    public Button button;

    public int spriteIndex;
    public int infectionStage = 0;

    private float elapsedTime;
    public float timeLimit = 2f;
    public float percentageOfResist = 0.8f;
    public float chanceOfDiseaseAppearing = 0f;


    public UnityEvent leftClick;
    public UnityEvent rightClick;

    void Start()
    {
        button = GetComponent<Button>();
        button.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.5f;

    }

    void Update()
    {
        if (infectionStage == 0)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= timeLimit)
            {
                if (Random.Range(0f, 1f) < chanceOfDiseaseAppearing)
                {
                    infectionStage++;
                }
            }
        }
        if (infectionStage != 0)
        {
            DetermineSpriteIndex();
        }
    }

 

    public void DetermineSpriteIndex()
    {
        if(infectionStage == -1)
        {
            spriteIndex = spriteList.Length - 1;
            state = "Dead";
        }
        else
        {
            spriteIndex = infectionStage;
        }
        button.GetComponent<Image>().sprite = spriteList[spriteIndex];

    }


    public void Resist()
    {
        if (Random.Range(0f, 1f) > percentageOfResist) // If the value is superior to the percentage it doesn't resist the disease
        {
            if (infectionStage == spriteList.Length-1)
            {
                infectionStage = -1;
            }
            if (infectionStage != -1)
            {
                infectionStage += 1;
            }

        }
    }



    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            Cut();

        else if (eventData.button == PointerEventData.InputButton.Right)
            Heal();
    }

    public void Heal()
    {
        if (state == "Alive")
        {
            infectionStage = 0;
        }
    }

    public void Cut()
    {
        infectionStage = -1;
        button.GetComponent<Image>().sprite = spriteList[spriteList.Length - 1];
        state = "Dead";
        button.interactable = false;
    }
}

