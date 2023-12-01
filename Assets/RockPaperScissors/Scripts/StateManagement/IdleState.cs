using UnityEngine;
using UnityEngine.AI;

public class IdleState : State
{
    Vector3 targetPoint;

    public IdleState(Symbol player, Symbol enemy) : base(player, enemy) {
    }

    private Vector3 GenerateRandomPointOnTerrain() {
        var point = new Vector3(Random.Range(0, 100f), 100f, Random.Range(0, 100f));
        if(Physics.Raycast(point, Vector3.down, out RaycastHit hit, 110f)) {
            if(NavMesh.SamplePosition(hit.point, out NavMeshHit h, 1f, NavMesh.AllAreas)) {
                GameObject.CreatePrimitive(PrimitiveType.Cube).transform.position = h.position;
                return h.position;
            } else {
                return GenerateRandomPointOnTerrain();
            }
        } else { 
            return GenerateRandomPointOnTerrain(); 
        }
    }

    public override void InitState() {
        targetPoint = GenerateRandomPointOnTerrain();
    }

    public override void Update() {
        agent.SetDestination(targetPoint);
        if(Vector3.Distance(agent.transform.position, targetPoint) < 1) {
            targetPoint = GenerateRandomPointOnTerrain();
        }
    }

    public override State TryToChangeState() {
        if(Vector3.Distance(enemySymbol.transform.position, playerSymbol.transform.position) < 15f) {
            var res = enemySymbol.CurrentSymbol.Beats(playerSymbol.CurrentSymbol);
            
            if (res.HasValue) {
                if (res.Value)
                    return new AttackState(playerSymbol, enemySymbol);
                else
                    return new FleeState(playerSymbol, enemySymbol);
            } else {
                return null;
            }
        }
        return null;
    }

}
