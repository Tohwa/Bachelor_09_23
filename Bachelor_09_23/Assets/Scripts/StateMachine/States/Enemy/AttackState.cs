using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackState : BaseState
{
    public AttackState(Enemy _enemy, StateMachine _stateMachine, NPCData _npcData) : base(_enemy, _stateMachine, _npcData)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        Debug.Log("entered AttackState");
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (enemy.canAttack)
        {
            Debug.Log("Attacked");
            enemy.StartCoroutine(enemy.AttackDelay());
        }

        if (enemy.fence.durability <= 0)
        {
            enemy.objectTarget = null;
            enemy.EnemyStateMachine.ChangeEnemyState(enemy.LocateState);
        }
        else if (enemy.sheepData.healthPoints <= 0)
        {
            enemy.objectTarget = null;
            enemy.EnemyStateMachine.ChangeEnemyState(enemy.LocateState);
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
