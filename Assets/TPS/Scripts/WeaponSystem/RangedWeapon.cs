using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangedWeapon : Weapon
{
    [SerializeField]
    protected int maxAmmo;
    protected int currentAmmo;

    [SerializeField]
    protected Rigidbody bulletPrefab;

    [SerializeField]
    protected Transform bulletSpawnPoint;

    protected override void Start()
    {
        base.Start();
        currentAmmo = maxAmmo;
    }

    public override void Attack()
    {
        if(currentAmmo > 0) {
            Shoot();
            currentAmmo--;
        }
    }

    protected virtual void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        bullet.AddForce(bullet.transform.forward * 100, ForceMode.Impulse);
        Destroy(bullet.gameObject, 4);
    }
}
