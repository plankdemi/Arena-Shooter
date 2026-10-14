using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Enemy enemy;
    public GameObject player;
    public float speed = 3;
    Vector3 direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        enemy = Enemies.BasicEnemy;
        player = GameObject.FindGameObjectWithTag("Player");


    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            direction = player.transform.position - transform.position;
            transform.position += direction * Time.deltaTime * speed;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            enemy.LowerHealth();
            if (enemy.Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
