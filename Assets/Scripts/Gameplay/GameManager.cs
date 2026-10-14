using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI health;
    public TextMeshProUGUI score;
    public GameObject player;
    public GameObject[] enemies;
    private int InitialEnemyCount;
    private int EnemyCount;
    private int wave = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InitialEnemyCount = 3;
        SpawnController.SpawnEnemies(InitialEnemyCount);
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        EnemyCount = enemies.Length + 1;

    }
    private void Update()
    {
        if (EnemyCount <= 0)
        {
            ++wave;
            SpawnController.SpawnEnemies(InitialEnemyCount + wave);
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            EnemyCount = enemies.Length;
            foreach (GameObject enemy in enemies)
            {
                if (enemy)
                {
                    enemy.GetComponent<EnemyController>().EnemyKilled += UpdateScoreUI;
                }

            }
        }
    }
    private void OnEnable()
    {
        player.GetComponent<PlayerController>().GetHit += UpdateHealthUI;
        foreach (GameObject enemy in enemies)
        {
            if (enemy)
            {
                enemy.GetComponent<EnemyController>().EnemyKilled += UpdateScoreUI;
            }

        }
    }
    private void OnDisable()
    {
        player.GetComponent<PlayerController>().GetHit -= UpdateHealthUI;
        foreach (GameObject enemy in enemies)
        {
            if (enemy)
            {
                enemy.GetComponent<EnemyController>().EnemyKilled -= UpdateScoreUI;
            }

        }
    }
    void Start()
    {
        UpdateHealthUI();
        UpdateScoreUI();
    }

    private void UpdateHealthUI()
    {
        health.text = "HEALTH: " + player.GetComponent<PlayerController>().player.Health;
    }
    private void UpdateScoreUI()
    {
        --EnemyCount;
        score.text = "SCORE: " + player.GetComponent<PlayerController>().player.Score;
    }
}
