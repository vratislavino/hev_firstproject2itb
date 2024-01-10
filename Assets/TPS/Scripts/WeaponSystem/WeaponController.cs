using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    Weapon currentWeapon;


    // Update is called once per frame
    void Update()
    {   
        if(Input.GetButtonDown("Fire1"))
        {
            currentWeapon.Attack();
        }
    }
}
