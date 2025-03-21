using UnityEngine;

public class Ship : MonoBehaviour
{
    public KeyCode moveUp = KeyCode.UpArrow;  
    public KeyCode moveDown = KeyCode.DownArrow;    
    public KeyCode shootKey = KeyCode.Z;  
    public float speed = 10.0f;   
    public float boundY = 3f;    
    public GameObject projectilePrefab;  
    public float fireRate = 0.5f;  
    private float nextFire = 0f;  
    private Rigidbody2D rb2d;
    private Animator animator; // Adiciona o Animator

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Obtém o componente Animator
    }

    void Update()
    {
        // Controle do movimento
        float moveY = 0;

        if (Input.GetKey(moveUp))
        {
            moveY = speed;
        }
        else if (Input.GetKey(moveDown))
        {
            moveY = -speed;
        }

        rb2d.linearVelocity = new Vector2(0, moveY); // Corrigido para 'velocity'!


        // Limita a posição da nave
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, -boundY, boundY);
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
            Instantiate(projectilePrefab, transform.position + Vector3.right * 1f, Quaternion.identity);
        }
    }
}
