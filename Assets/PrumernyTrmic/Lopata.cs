using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lopata : FallingObject
{
    public override void Collect(PlayerMovement pm) {
        Debug.Log("Sebral jsi lopatu!");

        pm.ChangeSpeed(3, 3);

    }
}
