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

        enemy.FindTarget();
    }

    public override void ExitState()
    {
        base.ExitState();

    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (enemy.activeTarget != null)
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
