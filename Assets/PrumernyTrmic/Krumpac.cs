using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Krumpac : FallingObject
{
    public override void Collect(PlayerMovement pm) {
        Debug.Log("Sebral jsi krump·Ë!");

        pm.StartedToWork();
    }
}
