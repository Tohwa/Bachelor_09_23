using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CozyState : BaseState
{
    public CozyState(NeutralNPC _animal, StateMachine _stateMachine, NPCData _npcData) : base(_animal, _stateMachine, _npcData)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        animal.aggroTrigger.SetActive(false);
        Debug.Log("Sheep has entered the cozy State");
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(!animal.fence.activeSelf)
        {
            animal.SheepStateMachine.ChangeNPCState(animal.AlarmedState);
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
