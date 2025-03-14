using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private GameManager gameManager;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(Random.Range(-1f, 1f), 1).normalized * speed;

        // Corrigido: agora inicializa corretamente o gameManager
        gameManager = FindFirstObjectByType<GameManager>();

        if (gameManager == null)
        {
            Debug.LogError("GameManager não encontrado! Certifique-se de que há um GameManager na cena.");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            Destroy(collision.gameObject);
            if (gameManager != null)
            {
                gameManager.AddScore(10);
            }
        }
        else if (collision.gameObject.CompareTag("LoseZone"))
        {
            Debug.Log("A bola entrou na LoseZone!");
            if (gameManager != null)
            {
                gameManager.LoseLife();
                ResetBall(); // Certifique-se de resetar a bola
            }
        }
    }

    void ResetBall()
    {
        transform.position = Vector3.zero;
        rb.linearVelocity = new Vector2(Random.Range(-1f, 1f), 1).normalized * speed;
        Debug.Log("Bola resetada!");
    }
}
