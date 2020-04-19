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
    public UnityEvent middleClick;
    public UnityEvent rightClick;

    void Start()
    {
        button = GetComponent<Button>();
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
            spriteIndex = 6;
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
            if (infectionStage == 6)
            {
                infectionStage = -1;
            }
            if (infectionStage != -1)
            {
                infectionStage += 1;
            }

        }
    }

    public void Cut()
    {
        infectionStage = -1;
        button.GetComponent<Image>().sprite = spriteList[6];
        state = "Dead";
        button.interactable = false;
    }

    public void Heal()
    {
        infectionStage = 0;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
            Cut();

        else if (eventData.button == PointerEventData.InputButton.Right)
            Heal();
    }

}

