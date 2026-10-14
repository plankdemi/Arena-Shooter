using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI health;
    public TextMeshProUGUI score;
    public GameObject player;
    public GameObject[] enemies;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        //player = GameObject.FindGameObjectWithTag("Player");

    }
    private void OnEnable()
    {
        player.GetComponent<PlayerController>().GetHit += UpdateHealthUI;
    }
    private void OnDisable()
    {
        player.GetComponent<PlayerController>().GetHit -= UpdateHealthUI;
    }
    void Start()
    {
        UpdateHealthUI();
        UpdateScoreUI();
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void UpdateHealthUI()
    {
        health.text = "HEALTH:" + player.GetComponent<PlayerController>().player.Health;
    }
    private void UpdateScoreUI()
    {

    }
}
