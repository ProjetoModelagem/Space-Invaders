using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int lives = 3;
    public GUISkin layout;
    public float slowMotionScale = 0.5f; // Quanto desacelera (1.0 = normal, 0.5 = metade da velocidade)
    private float normalTimeScale = 1.0f; // Velocidade normal do jogo

    void Start()
    {
        Debug.Log("Jogo iniciado! Score: " + score + ", Vidas: " + lives);
    }

    void Update()
    {
        // Desacelera o tempo ao pressionar "V"
        if (Input.GetKeyDown(KeyCode.V))
        {
            Time.timeScale = slowMotionScale;
        }
        else if (Input.GetKeyUp(KeyCode.V))
        {
            Time.timeScale = normalTimeScale;
        }
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Pontos adicionados! Score atual: " + score);
        CheckWinCondition();
    }

    public void LoseLife()
    {
        lives--;
        Debug.Log("Vida perdida! Vidas restantes: " + lives);

        if (lives <= 0)
        {
            SceneManager.LoadScene("LoserScene");
        }
    }

    void CheckWinCondition()
    {
        if (SceneManager.GetActiveScene().name == "Lv1" && score == 80)
        {
            SceneManager.LoadScene("WinScene");
        }
    }

    void OnGUI()
    {
        GUI.skin = layout;
        GUI.Label(new Rect(Screen.width / 4 - 100, 10, 200, 40), "Score: " + score);
        GUI.Label(new Rect(Screen.width / 4 - 100, 40, 200, 30), "Lives: " + lives);

        if (GUI.Button(new Rect(Screen.width / 5 - 30, 80, 70, 30), "RESTART"))
        {
            RestartGame();
        }
    }

    private void RestartGame()
    {
        score = 0;
        lives = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // asteroide atinge a "Wall"
    public void AsteroidHitWall()
    {
        LoseLife(); // Perde uma vida
    }
}
