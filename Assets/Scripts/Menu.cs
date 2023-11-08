using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    public GUISkin layout;

     void OnGUI()
    {
        GUI.skin = layout;
        if (GUI.Button(new Rect(Screen.width / 2 - 100 -1 , 280, 280, 53), "PLAY GAME"))
        {
            SceneManager.LoadScene("Main");
        }
    }
}
