using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatroleState : State
{

    public PatroleState(MovementContoller _char, StateMachine sm) : base(_char, sm)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        character.Move();
    }

}
