using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public Func<string, bool> ControlFunction;

    public event Action<bool> PossibleToAttackChanged;

    public virtual float GetReloadProgress()
    {
        return 0;
    }

    protected void RaisePossibleToAttackChanged(bool possibleToAttack)
    {
        PossibleToAttackChanged?.Invoke(possibleToAttack);
    }

    public abstract void Attack();

    protected virtual void Start()
    {
        
    }

    public virtual void ResetReloadProgress() { }
}
