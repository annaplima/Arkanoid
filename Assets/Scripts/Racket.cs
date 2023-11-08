using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour
{
    [SerializeField]
    private float speed = 150;
    private Rigidbody2D body;
    private GameObject ball; // Referência para a bola
    private Vector3 initialBallPosition; // Posição inicial da bola

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        ball = GameObject.FindGameObjectWithTag("Ball"); // Encontre a bola com base na tag (certifique-se de que a bola tenha a tag "Ball")
        initialBallPosition = ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        body.velocity = Vector2.right * h * speed;
    }

    // Função para reposicionar a bola no Racket
    public void ResetBallPosition()
    {
        ball.transform.position = initialBallPosition;
        ball.GetComponent<Rigidbody2D>().velocity = Vector2.zero; // Pare o movimento da bola
    }
}
