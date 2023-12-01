using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    State currentState = null;

    // Start is called before the first frame update
    void Start()
    {
        var player = FindObjectsOfType<Symbol>().ToList().First(s => s.IsPlayer);

        currentState = new IdleState(player, GetComponent<Symbol>());
        currentState.InitState();
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Update();

        var newState = currentState.TryToChangeState();
        if(newState != null) {
            currentState = newState;
            currentState.InitState();
        }
    }
}
