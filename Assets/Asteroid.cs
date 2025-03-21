using UnityEngine;
using UnityEngine.SceneManagement;

public class Asteroid : MonoBehaviour
{
    public float speed = 5f;  
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.left * speed; // Move o asteroide para a esquerda
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            GameManager gm = FindFirstObjectByType<GameManager>();
            if (gm != null)
            {
                gm.AsteroidHitWall(); // Perde uma vida
            }
            Destroy(gameObject); // Destroi o asteroide
        }
        if (collision.CompareTag("Player")) // Se tocar no jogador
        {
            Debug.Log("O jogador foi atingido por um asteroide!");
            SceneManager.LoadScene("LoserScene"); // Encerra o jogo
        }
    }
}
