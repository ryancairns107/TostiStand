using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float rotationDamping = 20f;
    public float runSpeed = 10f;
    public int gravity = 20;
    public float jumpSpeed = 8;
    bool canJump;
    float moveSpeed;
    float verticalVel;  // Used for continuing momentum while in air    
    CharacterController controller;
    void Start()
    {
        controller = (CharacterController)GetComponent(typeof(CharacterController));
    }
    float UpdateMovement()
    {
        // Movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 inputVec = new Vector3(x, 0, z);
        inputVec *= runSpeed;
        controller.Move((inputVec + Vector3.up * -gravity + new Vector3(0, verticalVel, 0)) * Time.deltaTime);
        // Rotation
        if (inputVec != Vector3.zero)
            transform.rotation = Quaternion.Slerp(transform.rotation,
                Quaternion.LookRotation(inputVec),
                Time.deltaTime * rotationDamping);
        return inputVec.magnitude;
    }
    void Update()
    {
        // Check for jump

        // Actually move the character
        moveSpeed = UpdateMovement();
       
    }
}