using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Pause : MonoBehaviour
{

    public RectTransform Panel;
    public static bool g_Paused = false;


    void Update()
    {
        if (Input.GetButtonDown("Escape"))
        {
            OpenPause();
        }
    }


    public void OpenPause()
    {
        Panel.transform.localScale = new Vector3(0.8f, 0.8f);
        g_Paused = true;
    }
    public void ClosePause()
    {
        Panel.transform.localScale = new Vector3(0, 0);
    }

}
