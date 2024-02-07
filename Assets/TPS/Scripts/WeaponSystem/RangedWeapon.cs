using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RangedWeapon : Weapon
{
    [SerializeField]
    protected int maxAmmo;
    protected int currentAmmo;

    [SerializeField]
    protected float fireRate;
    protected float fireCooldown;

    [SerializeField]
    protected float reloadTime;
    protected float reloadProgress;


    [SerializeField]
    protected Rigidbody bulletPrefab;

    [SerializeField]
    protected Transform bulletSpawnPoint;

    protected override void Start()
    {
        base.Start();
        ControlFunction = Input.GetButtonDown;
        currentAmmo = maxAmmo;
    }

    public override void Attack()
    {
        if(currentAmmo > 0 && fireCooldown <= 0 && reloadProgress <= 0) {
            Shoot();
            fireCooldown = fireRate;
            currentAmmo--;
        }
    }

    public override float GetReloadProgress()
    {
        return reloadProgress / reloadTime;
    }

    private void Update()
    {
        if(reloadProgress > 0)
        {
            reloadProgress -= Time.deltaTime;
            if(reloadProgress <= 0) {
                currentAmmo = maxAmmo;
                RaisePossibleToAttackChanged(true);
            }
        }

        if(Input.GetButtonDown("Reload"))
        {
            reloadProgress = reloadTime;
            RaisePossibleToAttackChanged(false);
        }

        fireCooldown -= Time.deltaTime;   
    }

    protected virtual void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.AddForce(bullet.transform.forward * 100, ForceMode.Impulse);
        Destroy(bullet.gameObject, 4);
    }

    public override void ResetReloadProgress()
    {
        reloadProgress = reloadTime;
    }
}
