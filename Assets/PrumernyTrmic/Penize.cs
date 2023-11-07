using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penize : FallingObject
{
    public override void Collect(PlayerMovement pm) {
        Score.Instance.AddScore(4);
    }
}
