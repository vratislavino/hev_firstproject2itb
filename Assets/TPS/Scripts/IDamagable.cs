using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    int Hp { get; set; }

    void DoDmg(int dmg);

    void Die();
}
