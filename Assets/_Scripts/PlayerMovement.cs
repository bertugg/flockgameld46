using System;
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

    private bool isSleeping = false;
    private GameManager game;

    private void Start()
    {
        game = GameManager.Instance;
    }

    void Update()
    {
        if (isSleeping)
        {
            game.Energy += Time.deltaTime * 5;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                WakeUp();
            }
        }
        else if (game.IsControllerOpen)
        {
            game.Energy -= Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                game.IsPaused = true;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Bark!");
                animator.SetTrigger("Bark");
                game.audioManager.Play(FlockAudioManager.AudioName.DogBark);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SleepZone"))
        {
            transform.position.Set(other.transform.position.x, transform.position.y, other.transform.position.z);
            Sleep();
        }
    }

    public void Sleep()
    {
        isSleeping = true;
        GameManager.Instance.audioManager.Play(FlockAudioManager.AudioName.Snoring);
        GameManager.Instance.levelChanger.PlayFadeOut();
    }

    public void WakeUp()
    {
        isSleeping = false;
        GameManager.Instance.audioManager.Stop(FlockAudioManager.AudioName.Snoring);
        GameManager.Instance.levelChanger.PlayFadeIn();
    }
}