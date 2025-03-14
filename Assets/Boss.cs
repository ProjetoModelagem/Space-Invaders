using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int health = 3; // O boss começa com 3 vidas
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager não encontrado!");
        }
    }

    public void TakeDamage()
    {
        health--; // Reduz 1 vida do boss

        Debug.Log("Boss atingido! Vidas restantes: " + health);

        if (health <= 0)
        {
            Destroy(gameObject); // Destroi o boss quando suas vidas acabam
            
            // Adiciona mais pontos ao jogador ao derrotar o boss
            if (gameManager != null)
            {
                gameManager.AddScore(10); // O boss vale mais pontos
            }
        }
    }
}
