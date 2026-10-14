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
        transform.position += new Vector3(moveInput.x, moveInput.y, 0) * Time.deltaTime * speed;
        RotateTowards();




    }
    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    private Vector3 GetMousePos()
    {
        Vector3 mousepos = Mouse.current.position.ReadValue();

        return Camera.main.ScreenToWorldPoint(mousepos);
    }
    private void RotateTowards()
    {
        direction = (GetMousePos() - transform.position);
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
