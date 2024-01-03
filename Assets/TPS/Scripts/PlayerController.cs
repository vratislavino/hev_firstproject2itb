using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    Vector3 cameraRotation;
    Vector3 rotation;

    [SerializeField] Transform cameraHolder;

    [SerializeField] float sensitivity;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        DoRotation();
        DoMovement();
    }

    private void DoMovement() {
        float side = Input.GetAxis("Horizontal"); // od -1 do 1
        float forward = Input.GetAxis("Vertical");
        float yMovement = rb.velocity.y;

        if (Input.GetButtonDown("Jump"))
        {
            yMovement = jumpForce;
        }


        var dir = new Vector3(side, 0, forward);
        var transformedDir = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * dir;
        
        rb.velocity = new Vector3(transformedDir.x * speed, yMovement, transformedDir.z * speed);
        
    }

    private void DoRotation() {
        float xRot = Input.GetAxisRaw("Mouse X");
        float yRot = Input.GetAxisRaw("Mouse Y");

        cameraRotation.x -= yRot * sensitivity;
        rotation.y += xRot * sensitivity;

        transform.rotation = Quaternion.Euler(rotation);

        cameraRotation.x = Mathf.Clamp(cameraRotation.x, -50, 80);
        cameraHolder.localRotation = Quaternion.Euler(cameraRotation);
    }
}
