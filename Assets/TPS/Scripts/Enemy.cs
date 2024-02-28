using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamagable
{
    protected PlayerController playerController;

    [SerializeField]
    protected int MaxHp;
    public int Hp { get; set; }

    public void Die()
    {
        FindObjectOfType<ScoreChanger>().AddScore();
        Destroy(gameObject);
    }

    public void DoDmg(int dmg)
    {
        Hp -= dmg;
        if (Hp <= 0) Die();
    }

    protected virtual void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        Hp = MaxHp;
    }
}
