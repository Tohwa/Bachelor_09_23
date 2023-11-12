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
        Debug.Log("Locating...");
    }

    public override void ExitState()
    {

    }

    public override void LogicUpdate()
    {
        enemy.FindTarget();

        if (enemy.activeTarget != null)
        {
            if (enemy.activeTarget.CompareTag("Fence"))
            {
                enemy.EnemyStateMachine.ChangeEnemyState(enemy.ChaseState);
            }
            else if (enemy.activeTarget.CompareTag("Sheep"))
            {
                enemy.EnemyStateMachine.ChangeEnemyState(enemy.ChaseAttackState);
            }
            else if (enemy.activeTarget.CompareTag("Player"))
            {
                enemy.EnemyStateMachine.ChangeEnemyState(enemy.ChaseAttackState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
    }

}
