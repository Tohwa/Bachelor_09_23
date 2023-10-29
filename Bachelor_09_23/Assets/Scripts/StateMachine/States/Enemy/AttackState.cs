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

    }

    public override void ExitState()
    {
    }

    public override void LogicUpdate()
    {
        if (enemy.canAttack && enemy.activeTarget != null)
        {
            Debug.Log("Attacked");
            enemy.StartCoroutine(enemy.AttackDelay());
        }

        if (enemy.fenceData.durability == 0)
        {
            enemy.activeTarget = null;
            enemy.canAttack = true;
            enemy.EnemyStateMachine.ChangeEnemyState(enemy.LocateState);
        }
    }

    public override void PhysicsUpdate()
    {

    }

    public override void UpdateState()
    {

    }
}
