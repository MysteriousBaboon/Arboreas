using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Script_UI : MonoBehaviour
{
    //public AudioSource audioData;
    //public AudioClip sound;
    public string levelName;
    public Text volume;

    public void GotoScene()
    {
      //  audioData.PlayOneShot(sound);
        SceneManager.LoadScene(levelName);

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void VolumeSlider(float sliderValue)
    {
        volume.text = sliderValue.ToString();
        AudioListener.volume = sliderValue / 100;
    }

    void Start()
    {
       // audioData = GetComponent<AudioSource>();

    }
}
