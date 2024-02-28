using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    [SerializeField] Transform shootPoint;

    [SerializeField] Bullet bulletPrefab;

    [SerializeField] float shootInterval = 2;
    private float currentShootCooldown = 0;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        currentShootCooldown = shootInterval;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerController.transform);

        if(currentShootCooldown > 0)
        {
            currentShootCooldown -= Time.deltaTime;
            if(currentShootCooldown <= 0)
            {
                Shoot();
                currentShootCooldown = shootInterval;
            }
        }
    }

    private void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        var rb = bullet.GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.AddForce(bullet.transform.forward * 50, ForceMode.Impulse);

        Destroy(bullet.gameObject, 4);
    }
}
