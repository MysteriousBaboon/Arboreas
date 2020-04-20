using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_PauseAudio : MonoBehaviour
{

    void Start()
    {
        Script_Sound.Instance.gameObject.GetComponent<AudioSource>().Stop();
    }


}
