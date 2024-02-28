using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{
    Weapon currentWeapon;
    List<Weapon> weapons;

    [SerializeField]
    private GameObject normalCrosshair;

    [SerializeField]
    private GameObject reloadCrosshair;

    [SerializeField]
    private Image reloadImage;

    [SerializeField]
    private Grenade grenadePrefab;
    [SerializeField]
    private Transform grenadeThrowPosition;
    [SerializeField]
    private Transform cameraRef;
    private void Start()
    {
        weapons = GetComponentsInChildren<Weapon>(true).ToList();
        ChangeWeapon(weapons.First());
    }

    private void ChangeWeapon(Weapon weapon)
    {
        if(currentWeapon == weapon) return;
        if(currentWeapon != null)
        {
            currentWeapon.PossibleToAttackChanged -= OnPossibleToAttackChanged;
            if(currentWeapon.GetReloadProgress() > 0)
            {
                currentWeapon.ResetReloadProgress();
            }
            currentWeapon.gameObject.SetActive(false);
        }

        currentWeapon = weapon;
        currentWeapon.PossibleToAttackChanged += OnPossibleToAttackChanged;
        currentWeapon.gameObject.SetActive(true);

        OnPossibleToAttackChanged(currentWeapon.GetReloadProgress() <= 0);
    }

    private void OnPossibleToAttackChanged(bool isPossible)
    {
        normalCrosshair.SetActive(isPossible);
        reloadCrosshair.SetActive(!isPossible);
    }

    // Update is called once per frame
    void Update()
    {   
        if(currentWeapon.ControlFunction("Fire1"))
        {
            currentWeapon.Attack();
        }

        if(currentWeapon.GetReloadProgress() > 0)
        {
            reloadImage.fillAmount = currentWeapon.GetReloadProgress();
        }

        if(Input.GetKeyDown(KeyCode.G))
        {
            ThrowGrenade();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) ChangeWeapon(weapons.ElementAt(0));
        if (Input.GetKeyDown(KeyCode.Alpha2)) ChangeWeapon(weapons.ElementAt(1));
        if (Input.GetKeyDown(KeyCode.Alpha3)) ChangeWeapon(weapons.ElementAt(2));
    }

    private void ThrowGrenade()
    {
        //var rot = 

        var g = Instantiate(grenadePrefab, grenadeThrowPosition.position, cameraRef.rotation);
        var rb = g.GetComponent<Rigidbody>();
        g.transform.Rotate(Vector3.right, 45, Space.Self);
        rb.AddForce(g.transform.forward * 100, ForceMode.Impulse);
    }
}
