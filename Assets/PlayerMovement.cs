using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;

    public float speed = 6.0f;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {

    }

    void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        moveDirection *= speed;

        characterController.Move(moveDirection * Time.deltaTime);
    }
}