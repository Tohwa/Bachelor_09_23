using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class ChaseState : BaseState
{
    public ChaseState(Enemy _enemy, StateMachine _stateMachine, NPCData _npcData) : base(_enemy, _stateMachine, _npcData)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        enemy.ChaseTarget(enemy.objectTarget);

        if (!enemy.Agent.pathPending)
        {
            if (enemy.Agent.remainingDistance <= enemy.Agent.stoppingDistance)
            {
                if (!enemy.Agent.hasPath || enemy.Agent.velocity.sqrMagnitude == 0f)
                {
                    enemy.EnemyStateMachine.ChangeEnemyState(enemy.AttackState);                    
                }
            }
        }
        else if (enemy.objectTarget == null)
        {
            enemy.EnemyStateMachine.ChangeEnemyState(enemy.LocateState);
        }
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }
}
