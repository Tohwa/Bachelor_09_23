using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeState : BaseState
{
    public EscapeState(NeutralNPC _animal, StateMachine _stateMachine, NPCData _npcData) : base(_animal, _stateMachine, _npcData)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        Debug.Log("Sheep is running away!");
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(GameManager.Instance.GameState.curGameState == GameManager.Instance.PrepState)
        {
            animal.SheepStateMachine.ChangeNPCState(animal.ReturnState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }
}
