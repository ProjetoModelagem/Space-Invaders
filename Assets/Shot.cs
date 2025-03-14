using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Shot : MonoBehaviour
{
    public float speed = 8f; // Velocidade do tiro
    private Rigidbody2D rb;
    private GameManager gameManager;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.up * speed; // Movimento para cima (ajuste para tiros do alien no script do Alien)

        // Obtém a referência do GameManager
        gameManager = FindAnyObjectByType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager não encontrado!");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Se o tiro do jogador acertar um alien comum
        if (gameObject.CompareTag("PlayerShot") && collision.gameObject.CompareTag("Alien"))
        {
            Destroy(collision.gameObject); // Destroi o alien
            Destroy(gameObject); // Destroi o tiro

            // Adiciona 10 pontos ao score
            if (gameManager != null)
            {
                gameManager.AddScore(10);
            }
        }
        // Se o tiro do jogador acertar o BOSS
        else if (gameObject.CompareTag("PlayerShot") && collision.gameObject.CompareTag("Boss"))
        {
            Boss boss = collision.gameObject.GetComponent<Boss>(); // Obtém o script do boss
            if (boss != null)
            {
                boss.TakeDamage(); // Chama a função para reduzir a vida do boss
            }
            Destroy(gameObject); // Destroi o tiro
        }
        // Se o tiro do alien acertar o jogador
        else if (gameObject.CompareTag("AlienShot") && collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject); // Destroi o tiro

            // Diminui a vida do jogador em 1
            if (gameManager != null)
            {
                gameManager.LoseLife();
            }
        }
        // Se atingir a parede ou a LoseZone, destrói o tiro
        else if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("LoseZone"))
        {
            Destroy(gameObject);
        }
    }
}
