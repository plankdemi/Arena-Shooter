using System.Timers;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    public Weapon weapon;
    private PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        playerController.Shoot += Shoot;
        weapon = Weapons.pistol;
    }

    public void Shoot()
    {
        if (weapon.CanShoot)
        {
            weapon.CanShoot = false;
            GameObject bullet = Instantiate((GameObject)Resources.Load("Projectile"), playerController.gameObject.transform.position, playerController.gameObject.transform.rotation);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.linearVelocity = playerController.GetDirection().normalized * 20f;



            //TODO FIX SCUFFED TIMER 
            System.Timers.Timer timer = new System.Timers.Timer(weapon.ShootCD * 1000);
            timer.Elapsed += CooldownFinished;
            timer.Enabled = true;


        }
    }
    private void CooldownFinished(object sender, ElapsedEventArgs e)
    {
        weapon.CanShoot = true;
    }
}
