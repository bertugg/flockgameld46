using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SheepBehaviour : MonoBehaviour
{
    Transform target;
    NavMeshAgent agent;

    SheepState sheepState;
    float timer;
    private Vector3 wanderDirection;

    private enum SheepState
    {
        HangoutWithHerd,
        Wander,
        Abducted
    }

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("SheepMovementTarget").transform;
        agent = GetComponent<NavMeshAgent>();

        sheepState = SheepState.HangoutWithHerd;
        SetRandomTimer();
    }


    private void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else if(sheepState != SheepState.Wander)
        {
            SetRandomWanderDirection();
            sheepState = SheepState.Wander;
            SetRandomTimer();
        }
        switch (sheepState)
        {
            case SheepState.HangoutWithHerd:
                agent.SetDestination(target.position);
                transform.rotation = Quaternion.identity;
                break;
            case SheepState.Wander:
                transform.position += wanderDirection * agent.speed * Time.deltaTime;
                break;
            case SheepState.Abducted:
                //Wolf catch part
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 8)//Bark
        {
            sheepState = SheepState.HangoutWithHerd;
            SetRandomTimer();
        }
    }

    private void SetRandomTimer()
    {
        timer = Random.Range(5, 10);
    }
    private void SetRandomWanderDirection()
    {
        wanderDirection = new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f));
        wanderDirection = wanderDirection.normalized;
    }
}