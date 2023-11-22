using UnityEngine;

public class IdleState : State
{
    public IdleState(Symbol player, Symbol enemy) : base(player, enemy) {
    }

    public override void InitState() {
        throw new System.NotImplementedException();
    }

    public override State TryToChangeState() {
        throw new System.NotImplementedException();
    }

    public override void Update() {
        throw new System.NotImplementedException();
    }
}
