using UnityEngine;

public class Weapon
{
    public enum WeaponType
    {
        pistol,
        shotgun,
        machine_gun,

    }
    public string Name { get; set; }
    public WeaponType Type { get; }
    public int BulletsPerClip { get; }
    public float ReloadTime { get; }
    public float ShootCD { get; }
    public bool CanShoot { get; set; } = true;
    public GameObject projectile;

    public Weapon(string name, WeaponType type)
    {
        Name = name;
        Type = type;
        if (type == WeaponType.pistol)
        {
            BulletsPerClip = 6;
            ReloadTime = 3f;
            ShootCD = 1f;
        }
        else if (type == WeaponType.shotgun) { }
        else if (type == WeaponType.machine_gun) { }


    }





}
