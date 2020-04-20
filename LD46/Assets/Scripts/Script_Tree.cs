using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Script_Tree : MonoBehaviour, IPointerClickHandler
{
    public string state = "Alive";
    public Sprite[] spriteList;
    public Sprite stump;
    public Button button;

    public AudioSource audioData;
    public AudioClip[] sound;
    public int spriteIndex;
    public int infectionStage = 0;

    private float elapsedTime;
    public float timeLimit = 2f;
    public float diseaseLimit = 5f;
    public float percentageOfResist = 0.8f;
    public float chanceOfDiseaseAppearing = 0f;
    private bool hasHeal = false;
    private float elapsedCD;


    public UnityEvent leftClick;
    public UnityEvent rightClick;

    void Start()
    {
        button = GetComponent<Button>();
        audioData = GetComponent<AudioSource>();
        button.GetComponent<Image>().alphaHitTestMinimumThreshold = 0.5f;

    }

    void Update()
    {
        elapsedCD += Time.deltaTime;
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

        if (infectionStage > 0)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= diseaseLimit)
            {
                    infectionStage++;
            }
        }
        DetermineSpriteIndex();

    }



    public void DetermineSpriteIndex()
    {
        if(infectionStage == -1)
        {
            spriteIndex = spriteList.Length - 1;
            state = "Dead";
        }
        if(infectionStage != -1 && infectionStage != -2)
        {
            spriteIndex = infectionStage;
        }
        if (infectionStage != -2)
        {
            button.GetComponent<Image>().sprite = spriteList[spriteIndex];
        }

    }


    public void Resist()
    {
        if (Random.Range(0f, 1f) > percentageOfResist) // If the value is superior to the percentage it doesn't resist the disease
        {
            if (infectionStage == spriteList.Length-1)
            {
                infectionStage = -1;
            }
            if (infectionStage < 0)
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
        if (state == "Alive" && hasHeal == false)
        {
            audioData.pitch = (Random.Range(0.4f, .9f));
            audioData.PlayOneShot(sound[1]);

            // cd_Heal = max_Heal;
            hasHeal = true;
            infectionStage = 0;
        }
    }

    public void Cut()
    {
        audioData.pitch = (Random.Range(0.4f, .9f));
        audioData.PlayOneShot(sound[0]);

        audioData.PlayOneShot(sound[2]);
        infectionStage = -2;
        button.GetComponent<Image>().sprite = stump;
        state = "Dead";
        button.interactable = false;
    }
}

