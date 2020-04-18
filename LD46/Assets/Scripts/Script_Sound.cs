using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Sound : MonoBehaviour
{

    private static Script_Sound instance = null;
    public static Script_Sound Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
