using UnityEngine;

public class _Shot : MonoBehaviour
{
    public float speed = 8f; // Velocidade do tiro
    private Rigidbody2D rb;
    private GameManager gameManager;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.right * speed; // Movimento do tiro para a direita

        if (rb == null)
        {
            Debug.LogError("Rigidbody2D não encontrado no tiro!");
        }

        // Obtém a referência do GameManager
        gameManager = FindFirstObjectByType<GameManager>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager não encontrado!");
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Destroy(collision.gameObject); // Destroi o asteroide
            Destroy(gameObject); // Destroi o tiro
            if (gameManager != null)
            {
                gameManager.AddScore(10);
            }
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject); // Se bater na parede, o tiro some
        }
    }
}
