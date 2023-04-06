using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public IdleState(MovementContoller _char, StateMachine machine) : base(_char, machine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        character.agent.isStopped = true;
        character.StartCoroutine(character.TimeToMove());
    }
    public override void Exit()
    {
        base.Exit();
        character.agent.isStopped = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }



}
