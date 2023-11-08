using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GUISkin layout;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnGUI()
    {
        GUI.skin = layout;
        float centerX = Screen.width / 2;
        float centerY = Screen.height / 2;

        GUI.Label(new Rect(Screen.width / 2 - 100 - 15, 110, 300, 300), "GAME OVER");
        //GUI.Label(new Rect(Screen.width / centerX , centerY, 300, 300), "GAME OVER");


        if (GUI.Button(new Rect(Screen.width / 2 - 100 -3 , 200, 120, 53), "MENU"))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}