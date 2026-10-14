using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 moveInput;
    public int speed;
    public Player player;
    public event Action Shoot;
    public event Action GetHit;
    private Vector3 direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        moveInput = Vector2.zero;
        speed = 5;
        player = new Player();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)moveInput * Time.deltaTime * speed;
        RotateTowards();


    }
    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>().normalized;
    }
    private Vector2 GetMousePos()
    {
        Vector2 mousepos = Mouse.current.position.ReadValue();

        return Camera.main.ScreenToWorldPoint(mousepos);
    }
    private void RotateTowards()
    {
        direction = ((Vector3)GetMousePos() - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
    private void OnShoot()
    {
        Shoot?.Invoke();
    }
    public Vector3 GetDirection()
    {
        return direction;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            player.ReduceHealth();

            GetHit?.Invoke();
            if (player.Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
