using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public KeyCode moveRight = KeyCode.RightArrow;  // Mover para a direita
    public KeyCode moveLeft = KeyCode.LeftArrow;    // Mover para a esquerda
    public KeyCode shootKey = KeyCode.Z;           // Tecla para atirar
    public float speed = 10.0f;                     // Velocidade do paddle
    public float boundX = 3f;                       // Limite de movimentação horizontal
    public GameObject projectilePrefab;             // Prefab do tiro
    public float fireRate = 0.5f;                   // Tempo de delay entre tiros
    private float nextFire = 0f;                    // Tempo do próximo tiro
    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Controle do movimento
        Vector2 vel = rb2d.linearVelocity;
        if (Input.GetKey(moveRight))
        {
            vel.x = speed;
        }
        else if (Input.GetKey(moveLeft))
        {
            vel.x = -speed;
        }
        else
        {
            vel.x = 0;
        }
        rb2d.linearVelocity = vel;

        // Limitar a posição do paddle
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -boundX, boundX);
        transform.position = pos;

        // Disparo do projétil
        if (Input.GetKeyDown(shootKey) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        if (projectilePrefab)
        {
            Instantiate(projectilePrefab, transform.position + Vector3.up * 0.5f, Quaternion.identity);
        }
    }
}
