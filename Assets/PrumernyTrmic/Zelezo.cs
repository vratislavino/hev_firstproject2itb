using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zelezo : FallingObject
{
    public override void Collect(PlayerMovement pm) {
        Score.Instance.AddScore(10);
    }
}
