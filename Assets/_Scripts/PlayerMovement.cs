using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public Animator animator;

    public float speed = 6.0f;
    public GameObject barkZone;

    private float barkZoneTimer;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        
    }

    void Update()
    {
        if (GameManager.Instance.IsControllerOpen)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameManager.Instance.IsPaused = true;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Bark!");
                animator.SetTrigger("Bark");
                barkZoneTimer = 0.5f;
                barkZone.SetActive(true);
            }
            
            if(barkZoneTimer > 0)
            {
                barkZoneTimer -= Time.deltaTime;
            }
            else if(barkZone.activeInHierarchy)
            {
                barkZone.SetActive(false);
            }

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            moveDirection *= speed;

            characterController.Move(moveDirection * Time.deltaTime);

            animator.SetBool("Walking", moveDirection != Vector3.zero);
        }

    }

    
}