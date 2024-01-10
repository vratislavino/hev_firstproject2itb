using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
        var player = collision.gameObject.GetComponent<PlayerController>();
        player.Degravitate();
        Destroy(gameObject);
    }
}
