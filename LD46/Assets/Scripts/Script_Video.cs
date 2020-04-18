using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Script_Video : MonoBehaviour
{
    public VideoPlayer Video;
    public string SceneName;
    void Start()
    {
        Video.loopPointReached += LoadScene;
    }
    void Update()
    {
        if (Input.anyKeyDown)
        {

            SceneManager.LoadScene(SceneName);
        }
    }
    void LoadScene(VideoPlayer vp)
    {
        SceneManager.LoadScene(SceneName);
    }
}
