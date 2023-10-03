using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : Day
{
    public PlayerMoveState(Player _player, StateMachine _stateMachine, PlayerData _playerData) : base(_player, _stateMachine, _playerData)
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

        if(input.x == 0 && input.y == 0)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        player.MovePlayer(input.x, input.y);
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }
}
