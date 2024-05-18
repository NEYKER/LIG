using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(MeshCollider))]
public class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField] WeaponScriptable parabollicBulletScriptable;
    [SerializeField] Transform gunBarrel;

    MeshCollider meshCollider;
    Rigidbody rigidBody;
    int amountOfBulletsInMagazine;
    bool canShoot = true;
    bool isReloading;

    public Rigidbody RigidBody { get => rigidBody; }
    public MeshCollider MeshCollider { get => meshCollider; }

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        meshCollider = GetComponent<MeshCollider>();
    }

    public void InitializeWeapon()
    {
        amountOfBulletsInMagazine = parabollicBulletScriptable.BulletsPerMagazine;
    }

    public void Reload()
    {
        if (isReloading)
        {
            return;
        }
        StartCoroutine(WaitingReloadWeapon());
    }

    public void Shoot()
    {
        if (!canShoot || isReloading)
        {
            return;
        }
        if (amountOfBulletsInMagazine == 0)
        {
            Reload();
            return;
        }
        Bullet parabollicBullet = Instantiate(parabollicBulletScriptable.Bullet);
        parabollicBullet.transform.position = gunBarrel.position;
        Vector3 pushDirection = transform.forward;
        parabollicBullet.GetRigidbody().AddForce(pushDirection * parabollicBulletScriptable.PushForce, ForceMode.Impulse);
        amountOfBulletsInMagazine--;
        StartCoroutine(WaitShootingCadence());
    }

    public IEnumerator WaitShootingCadence()
    {
        canShoot = false;
        yield return new WaitForSeconds(parabollicBulletScriptable.ShootingCadencePerSeconds);
        canShoot = true;
    }

    public IEnumerator WaitingReloadWeapon()
    {
        isReloading = true;
        canShoot = false;
        yield return new WaitForSeconds(parabollicBulletScriptable.ReloadTimeInSeconds);
        canShoot = true;
        isReloading = false;
        amountOfBulletsInMagazine = parabollicBulletScriptable.BulletsPerMagazine;
    }
}