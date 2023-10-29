using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class ChaseAttackState : BaseState
{
    public ChaseAttackState(Enemy _enemy, StateMachine _stateMachine, NPCData _npcData) : base(_enemy, _stateMachine, _npcData)
    {
    }

    public override void EnterState()
    {
    }

    public override void ExitState()
    {
        Debug.Log("No longer chaseAttacking");
    }

    public override void LogicUpdate()
    {
        if (enemy.canAttack && enemy.Agent.remainingDistance <= enemy.Agent.stoppingDistance * 4 && enemy.activeTarget != null)
        {
            Debug.Log("Attacked");
            enemy.StartCoroutine(enemy.AttackDelay());

            if (enemy.sheepData.healthPoints == 0)
            {
                enemy.activeTarget = null;
                enemy.canAttack = true;
                enemy.EnemyStateMachine.ChangeEnemyState(enemy.LocateState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        enemy.ChaseTarget(enemy.activeTarget);
    }

    public override void UpdateState()
    {
    }
}
