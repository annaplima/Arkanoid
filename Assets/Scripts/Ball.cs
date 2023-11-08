using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float speed = 100f;
    private Rigidbody2D body;
    private Vector3 initialPosition; // Posição inicial da bola
    private GameObject racket; // Referência ao Racket
    private int currentScore = 0;

    // Referência ao script GameManager
    private GameManager gameManager;

     void GoBall()
    {
        body.velocity = Vector2.up * speed;
    }

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = Vector2.up * speed;
        initialPosition = transform.position;

        // Encontre o Racket com base em uma tag (certifique-se de que o Racket tenha a tag adequada)
        racket = GameObject.FindGameObjectWithTag("Racket");

        // Encontre o GameManager na cena
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        
    }

    float HitFactor(Vector2 ball, Vector2 player, float playerWidth)
    {
        return (ball.x - player.x) / playerWidth;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Racket")
        {
            float x = HitFactor(
                transform.position,
                col.transform.position,
                col.collider.bounds.size.x);

            Vector2 dir = new Vector2(x, 1).normalized;

            body.velocity = dir * speed;
        }
        else if (col.gameObject.CompareTag("Block"))
        {
            gameManager.score = currentScore++;
        }

        GetComponent<AudioSource>().Play();
    }

    void ResetBall()
    {
        body.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }
}
