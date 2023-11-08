using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives = 5; // Número de vidas iniciais
    public int score = 0; // Pontuação inicial
    private int totalBlocks; // Total de blocos na cena
    private int blocksDestroyed = 0; // Contagem de blocos destruídos
    public int currentPhase = 1;
    public Racket racket; // Referência ao script Racket
    public Ball ball; // Referência ao script Ball
    private string sceneName;

    private bool phase2Started = false;


    public GUISkin layout;

    void OnGUI () {
    GUI.skin = layout;
    GUI.Label(new Rect(Screen.width / 2 - 100 - 12, 20, 100, 100), "Pontos:  " + score);
    GUI.Label(new Rect(Screen.width / 2 + 100 + 12, 20, 100, 100), "Vidas:  " + lives);

    }

    // Referência ao GameManager para permitir Singleton
   // public static GameManager Instance;

   // void Awake()
    //{
        // Configura o Singleton do GameManager
      //  if (Instance == null)
     //   {
      //      Instance = this;
        //}
        //else
        //{
          //  Destroy(gameObject);
        //}
    //}

    void Start()
    {
        // Encontre todos os blocos na cena
        totalBlocks = GameObject.FindGameObjectsWithTag("Block").Length;
        sceneName = SceneManager.GetActiveScene().name;



    }

    // Função para atualizar a UI com vidas e pontuação

    // Função para lidar com a perda de vida
    public void LoseLife()
    {
        lives--;
        ball.SendMessage("RestartGame", 0.5f, SendMessageOptions.RequireReceiver);
    }
    

    void MudaFase()
        {
            if (sceneName == "Main" && score >= 51 && !phase2Started)
            {   
                phase2Started = true;
                currentPhase = 2;
                SceneManager.LoadScene("Fase2");
                
            }
        }
    void Update()
    {
        MudaFase();

        if(sceneName == "Fase2")
        {
            if(score >=71)
            SceneManager.LoadScene("Win");

            if(lives <= 0)
            SceneManager.LoadScene("GameOverScene");
            

        }

        if(lives <= 0)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }


    // Função para aumentar a pontuação
    public void IncreaseScore()
    {
        score++;
        blocksDestroyed++;

    }


}
