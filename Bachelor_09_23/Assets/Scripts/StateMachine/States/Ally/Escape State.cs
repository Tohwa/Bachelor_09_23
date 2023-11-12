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

        Debug.Log("Sheep is running away!");
    }

    public override void ExitState()
    {
    }

    public override void LogicUpdate()
    {

        animal.timer += Time.deltaTime;

        if (animal.timer >= animal.wanderTimer)
        {
            Vector3 newPos = animal.RandomNavSphere(animal.transform.position, animal.wanderRadius, 3);
            animal.Agent.SetDestination(newPos);
            animal.timer = 0;
        }

        //if (GameManager.Instance.GameState.curGameState == GameManager.Instance.PrepState)
        //{
        //    animal.SheepStateMachine.ChangeNPCState(animal.ReturnState);
        //}
    }

    public override void PhysicsUpdate()
    {
    }

}
