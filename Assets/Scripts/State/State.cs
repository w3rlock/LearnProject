using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected MovementContoller character;
    protected StateMachine stateMachine;

    protected State(MovementContoller _char, StateMachine machine)
    {
        this.character = _char;
        this.stateMachine = machine;
    }


    public virtual void LogicUpdate()
    {

    }

    public virtual void Enter()
    {
        Debug.Log("Init State");
    }

    public virtual void Exit()
    {

    }
}
