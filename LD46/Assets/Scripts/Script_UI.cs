using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Script_UI : MonoBehaviour
{
    public string LevelName;

    public void GotoScene()
    {
        SceneManager.LoadScene(LevelName);
    }

}
