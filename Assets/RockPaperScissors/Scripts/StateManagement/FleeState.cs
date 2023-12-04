using UnityEngine;

public class FleeState : State
{
    public FleeState(Symbol player, Symbol enemy) : base(player, enemy) {
    }

    public override void InitState() { }

    public override void Update() {
        var dir = playerSymbol.transform.position - agent.transform.position;
        agent.SetDestination(agent.transform.position - dir);
    }

    public override State TryToChangeState() {

        if (Vector3.Distance(enemySymbol.transform.position, playerSymbol.transform.position) > 15f)
            return new IdleState(playerSymbol, enemySymbol);

        var res = enemySymbol.CurrentSymbol.Beats(playerSymbol.CurrentSymbol);

        if (res.HasValue) {
            if (res.Value)
                return new AttackState(playerSymbol, enemySymbol);
            else
                return null;
        } else {
            return new IdleState(playerSymbol, enemySymbol);
        }
    }

}
