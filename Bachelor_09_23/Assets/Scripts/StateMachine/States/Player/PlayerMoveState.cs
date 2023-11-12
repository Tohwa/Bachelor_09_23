using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : BaseState
{
    public PlayerMoveState(Player _player, StateMachine _stateMachine, PlayerData _playerData) : base(_player, _stateMachine, _playerData)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        Debug.Log("Player has entered is MoveState!");
    }

    public override void ExitState()
    {
        base.ExitState();

        Debug.Log("Player has left its MoveState.");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(player.input.x == 0 && player.input.y == 0)
        {
            stateMachine.ChangePlayerState(player.IdleState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        player.MovePlayer(player.input.x, player.input.y);
    }

}
