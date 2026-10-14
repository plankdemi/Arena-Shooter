using UnityEngine;

public class WeaponController : MonoBehaviour
{

    public Weapon weapon;
    private PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        weapon = Weapons.CreatePistol();
    }

    private void OnEnable()
    {
        playerController.Shoot += Shoot;

    }
    private void OnDisable()
    {
        playerController.Shoot -= Shoot;
    }

    private float nextShotTime;

    public void Shoot()
    {
        if (Time.time < nextShotTime)
        {
            return;
        }

        nextShotTime = Time.time + weapon.ShootCD;


        GameObject bullet = Instantiate((GameObject)Resources.Load("Projectile"), playerController.gameObject.transform.position, playerController.gameObject.transform.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.linearVelocity = playerController.GetDirection().normalized * 20f;



    }

}
