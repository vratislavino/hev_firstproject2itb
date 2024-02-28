using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    Rigidbody rb;
    [SerializeField] float speed;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerController.transform);
        // use rather velocity
        rb.MovePosition(transform.position + transform.forward * speed * Time.deltaTime);

        // not now :)
        /*
        transform.position = Vector3.MoveTowards(
            transform.position, 
            playerController.transform.position,
            Time.deltaTime * speed);
        */
        
    }
}
