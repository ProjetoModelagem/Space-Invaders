using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienAI : MonoBehaviour
{
    public float speed = 2.0f; // Velocidade do alien
    public float moveDistance = 5.0f; // Distância máxima que ele pode percorrer antes de mudar de direção
    public GameObject shotPrefab; // Prefab do tiro
    public Transform shotSpawn; // Posição de spawn do tiro
    public float minFireRate = 1.0f; // Tempo mínimo entre tiros
    public float maxFireRate = 3.0f; // Tempo máximo entre tiros

    private float direction = 1.0f; // Direção inicial (direita)
    private float startX;
    private float nextFire;
    private float timeSinceLastDrop = 0f; // Tempo desde a última descida

    void Start()
    {
        startX = transform.position.x;
        ScheduleNextShot();
    }

    void Update()
    {
        // Incrementa a velocidade a cada segundo
        speed += Time.deltaTime * 0.1f; // Ajuste o valor para aumentar mais rápido ou mais devagar

        // Movimento horizontal do alien
        transform.position += Vector3.right * direction * speed * Time.deltaTime;
        
        if (Mathf.Abs(transform.position.x - startX) >= moveDistance)
        {
            direction *= -1; // Inverte a direção
        }

        // Faz os aliens descerem 0.2 unidades a cada segundo
        timeSinceLastDrop += Time.deltaTime;
        if (timeSinceLastDrop >= 1f) // A cada 1 segundo
        {
            transform.position += Vector3.down * 0.2f;
            timeSinceLastDrop = 0f;
        }

        // Disparo aleatório
        if (Time.time > nextFire)
        {
            Shoot();
            ScheduleNextShot();
        }
    }

    void Shoot()
    {
        GameObject shot = Instantiate(shotPrefab, shotSpawn.position, Quaternion.identity);
        Rigidbody2D rb = shot.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.down * 8f; // Define a velocidade do tiro para baixo
        }
    }

    void ScheduleNextShot()
    {
        nextFire = Time.time + Random.Range(minFireRate, maxFireRate);
    }
}
