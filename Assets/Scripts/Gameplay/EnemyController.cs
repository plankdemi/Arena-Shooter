using System;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Enemy enemy;
    public GameObject player;
    public event Action EnemyKilled;
    public float speed = 3;
    Vector2 direction;

    void Awake()
    {
        enemy = Enemies.CreateBasicEnemy();
        player = GameObject.FindGameObjectWithTag("Player");


    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            direction = (player.transform.position - transform.position).normalized;
            transform.position += (Vector3)direction * Time.deltaTime * speed;
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            enemy.LowerHealth();
            if (enemy.Health <= 0)
            {
                player.GetComponent<PlayerController>().player.IncreaseScore(enemy.ScoreValue);
                EnemyKilled?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
