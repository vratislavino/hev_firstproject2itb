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
    [SerializeField] Transform groundChecker;

    [SerializeField] float sensitivity;
    [SerializeField] float baseSpeed;
    float envSpeedMultiplier = 1f;
    [SerializeField] float jumpForce;

    Rigidbody rb;
    private bool isGrounded = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        CheckGrounded();
        DoRotation();
        DoMovement();
    }

    void CheckGrounded()
    {
        if(Physics.Raycast(groundChecker.position, Vector3.down, 0.06f))
        {
            isGrounded = true;
        } else
        {
            isGrounded = false;
        }
    }

    private void DoMovement() {
        float side = Input.GetAxisRaw("Horizontal"); // od -1 do 1
        float forward = Input.GetAxisRaw("Vertical");
        float yMovement = rb.velocity.y;

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            yMovement = jumpForce;
        }

        // (0,0,1), 0,0,0.2 
        var dir = new Vector3(side, 0, forward).normalized;
        var transformedDir = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * dir;
        
        var runMult = Input.GetButton("Sprint") ? 1.5f : 1;

        var speed = baseSpeed * envSpeedMultiplier * runMult;

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

    internal void ChangeSpeedByEnv(float v)
    {
        envSpeedMultiplier = v;
    }

    internal void Degravitate()
    {
        rb.useGravity = false;
    }
}
