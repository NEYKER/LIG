using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapons")]
public class WeaponScriptable : ScriptableObject
{
    [SerializeField] Bullet bullet;

    [SerializeField] float shootingCadence;
    [SerializeField] float reloadTime;
    [SerializeField] float pushForce;

    [SerializeField] int bulletsPerMagazine;

    public float ShootingCadencePerSeconds { get => shootingCadence; set => shootingCadence = value; }
    public float ReloadTimeInSeconds { get => reloadTime; set => reloadTime = value; }
    public float PushForce { get => pushForce; set => pushForce = value; }
    public int BulletsPerMagazine { get => bulletsPerMagazine; set => bulletsPerMagazine = value; }
    public Bullet Bullet { get => bullet; set => bullet = value; }
}
