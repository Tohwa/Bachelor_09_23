using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocateTargetState : BaseState
{
    public LocateTargetState(Enemy _enemy, StateMachine _stateMachine, NPCData _npcData) : base(_enemy, _stateMachine, _npcData)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        Debug.Log("Enemy has entered is LocateState!");

        enemy.FindTarget();
    }

    public override void ExitState()
    {
        base.ExitState();

        Debug.Log("Enemy has left its LocateState.");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (enemy.objectTarget != null)
        {
            enemy.EnemyStateMachine.ChangeEnemyState(enemy.ChaseState);
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