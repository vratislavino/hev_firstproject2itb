using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sand : MonoBehaviour
{
    [SerializeField]
    PlayerController player;

    private void OnCollisionEnter(Collision collision)
    {
        if(player.gameObject == collision.gameObject)
        {
            player.ChangeSpeedByEnv(0.5f);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (player.gameObject == collision.gameObject)
        {
            player.ChangeSpeedByEnv(1);
        }
    }
}
