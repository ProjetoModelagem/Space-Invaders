using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int lives = 3;
    public GUISkin layout; // Fonte e estilo do placar na tela

    void Start()
    {
        Debug.Log("Jogo iniciado! Score: " + score + ", Vidas: " + lives);
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
                SceneManager.LoadScene("Lv2");
            }
            else if (SceneManager.GetActiveScene().name == "Lv2" && score == 10)
            {
                SceneManager.LoadScene("WinScene");
            }

    }
    // Exibir placar na tela
    void OnGUI()
    {
        GUI.skin = layout;

        // Exibir score e vidas
        GUI.Label(new Rect(Screen.width / 4 - 100, 10, 200, 40), "Score: " + score);
        GUI.Label(new Rect(Screen.width / 4 - 100, 40, 200, 30), "Lives: " + lives);

        // Botão de reiniciar jogo
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
}
