public static class Weapons
{
    public static Weapon CreatePistol()
    {
        return new Weapon("Glock", Weapon.WeaponType.pistol);
    }
}
