using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : Day
{

    public PlayerIdleState(Player _player, StateMachine _stateMachine, PlayerData _playerData) : base(_player, _stateMachine, _playerData)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        player.MovePlayer(0, 0);
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(input.x != 0 || input.y != 0)
        {
            stateMachine.ChangePlayerState(player.MoveState);
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
