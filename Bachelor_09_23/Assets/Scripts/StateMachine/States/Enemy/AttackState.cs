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

        Debug.Log("Enemy has entered is AttackState!");

        enemy.DestroyTarget();
        enemy.objectTarget = null;
    }

    public override void ExitState()
    {
        base.ExitState();

        Debug.Log("Enemy has left its AttackState.");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (enemy.objectTarget == null)
        {
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
