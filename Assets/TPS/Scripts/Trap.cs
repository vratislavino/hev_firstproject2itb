using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
        var player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.Degravitate();
            Destroy(gameObject);
        }
    }
}
