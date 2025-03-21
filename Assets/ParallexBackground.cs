using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    public float parallaxSpeed; // Velocidade do movimento
    private float length;
    private Vector3 startPos;

    void Start()
    {
        // Guarda a posição inicial e o tamanho da sprite
        startPos = transform.position;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        // Move o fundo para a esquerda continuamente
        transform.position += Vector3.left * parallaxSpeed * Time.deltaTime;

        // Quando a imagem sair completamente da tela, reposiciona ela para continuar o loop
        if (transform.position.x <= startPos.x - length)
        {
            transform.position += new Vector3(length * 2f, 0, 0);
        }
    }
}
