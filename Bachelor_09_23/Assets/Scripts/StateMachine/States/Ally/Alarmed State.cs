using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmedState : BaseState
{
    public AlarmedState(NeutralNPC _animal, StateMachine _stateMachine, NPCData _npcData) : base(_animal, _stateMachine, _npcData)
    {
    }

    public override void EnterState()
    {

        animal.aggroTrigger.SetActive(true);
        Debug.Log("Sheep has entered an Alarmed State");
    }

    public override void ExitState()
    {
    }

    public override void LogicUpdate()
    {

        if(animal.trigger.enemyClose == true)
        {
            animal.SheepStateMachine.ChangeNPCState(animal.EscapeState);
        }
    }

    public override void PhysicsUpdate()
    {
    }
}
