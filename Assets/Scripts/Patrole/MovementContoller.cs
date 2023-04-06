using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementContoller : MonoBehaviour
{
    #region Variables
    public IdleState idleState;
    public PatroleState patroleState;
    public StateMachine stateMachine;
    public NavMeshAgent agent;
    public List<Transform> points;
    private int pointIndex;
    #endregion

    #region Properties

    public IEnumerator TimeToMove()
    {
        yield return new WaitForSeconds(2);
        stateMachine.ChangeState(patroleState);
    }


    public void Move()
    {
        if (agent.remainingDistance < agent.stoppingDistance)
        {
            stateMachine.ChangeState(idleState);
            agent.SetDestination(points[pointIndex].position);
            pointIndex++;
            if (pointIndex == points.Count)
            {
                pointIndex = 0;
            }
        }
    }

    public void Idle()
    {

    }
    #endregion

    #region MonoCallbacks

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        stateMachine = new StateMachine();
        idleState = new IdleState(this, stateMachine);
        patroleState = new PatroleState(this, stateMachine);
        stateMachine.Initialize(idleState);
    }

    void Update()
    {
        stateMachine.currentState.LogicUpdate();
    }
    
    #endregion
}
