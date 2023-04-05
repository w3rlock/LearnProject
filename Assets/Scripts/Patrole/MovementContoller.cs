using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum PatroleState
{
    Idle,
    Move
}


public class MovementContoller : MonoBehaviour, IMovement
{
    public PatroleState currentState = PatroleState.Move;

    private NavMeshAgent agent;

    public List<Transform> points;
    private int pointIndex = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    void Update()
    {
        switch (currentState)
        {
            case PatroleState.Idle:
                Idle();
                break;
            case PatroleState.Move:
                Move();
                break;
        }
    }

    IEnumerator IdleToMoveCoroutine()
    {
        Debug.Log("CoroutineHasStarted");
        yield return new WaitForSeconds(3);
        Debug.Log("CoroutineEnd");
        IdleToMove();
    }


    public void Move()
    {
        if( agent.remainingDistance < agent.stoppingDistance)
        {
            MoveToIdle();
            agent.SetDestination(points[pointIndex].position);
            pointIndex++;
            if (pointIndex == points.Count)
            {
                pointIndex = 0;
            }
        }
    }

    public void IdleToMove()
    {
        agent.isStopped = false;
        Move();
        ChangeState(PatroleState.Move);
    }

    public void MoveToIdle()
    {
        Debug.Log("start idle");
        if(currentState == PatroleState.Move)
        {
            ChangeState(PatroleState.Idle);
            StartCoroutine(IdleToMoveCoroutine());
        }
    }

    public void Idle()
    {
        agent.isStopped = true;
    }


    private void ChangeState(PatroleState state)
    {
        currentState = state;
    }
}
