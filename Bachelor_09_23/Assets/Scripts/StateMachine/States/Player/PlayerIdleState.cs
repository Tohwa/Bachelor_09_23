using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : BaseState
{
    public PlayerIdleState(Player _player, StateMachine _stateMachine, PlayerData _playerData) : base(_player, _stateMachine, _playerData)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

        Debug.Log("Player has entered is IdleState!");

        player.MovePlayer(0, 0);
    }

    public override void ExitState()
    {
        base.ExitState();

        Debug.Log("Player has left its IdleState.");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(player.input.x != 0 || player.input.y != 0)
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
