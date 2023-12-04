using UnityEngine;

public class AttackState : State
{
    public AttackState(Symbol player, Symbol enemy) : base(player, enemy) {
    }

    public override void InitState() {
    }

    public override void Update() {
        agent.SetDestination(playerSymbol.transform.position);
    }

    public override State TryToChangeState() {
        if (Vector3.Distance(enemySymbol.transform.position, playerSymbol.transform.position) > 15f)
            return new IdleState(playerSymbol, enemySymbol);

        var res = enemySymbol.CurrentSymbol.Beats(playerSymbol.CurrentSymbol);

        if (res.HasValue) {
            if (res.Value)
                return null;
            else
                return new FleeState(playerSymbol, enemySymbol);
        } else {
            return new IdleState(playerSymbol, enemySymbol);
        }
    }

}
