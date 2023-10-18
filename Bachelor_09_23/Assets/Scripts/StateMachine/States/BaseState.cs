using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState
{
    #region Fields
    protected Player player;
    protected Enemy enemy;
    protected NeutralNPC animal;
    protected StateMachine stateMachine;
    protected PlayerData playerData;
    protected NPCData npcData;

    //private float startTime;

    //private string animBoolName;
    #endregion

    public BaseState(Enemy _enemy, StateMachine _stateMachine, NPCData _npcData/*, String _animBoolName */)
    {
        enemy = _enemy;
        stateMachine = _stateMachine;
        npcData = _npcData;
        //animBoolName = _animBoolName;
    }

    public BaseState(NeutralNPC _animal, StateMachine _stateMachine, NPCData _npcData/*, String _animBoolName */)
    {
        animal = _animal;
        stateMachine = _stateMachine;
        npcData = _npcData;
        //animBoolName = _animBoolName;
    }

    public BaseState(Player _player, StateMachine _stateMachine, PlayerData _playerData/*, String _animBoolName */)
    {
        player = _player;
        stateMachine = _stateMachine;
        playerData = _playerData;
        //animBoolName = _animBoolName;
    }

    public BaseState(StateMachine _stateMachine)
    {
        stateMachine = _stateMachine;
    }

    public virtual void EnterState()
    {
        //player.anim.setBool(animBoolName, true);
        //startTime = Time.time;
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }

    public virtual void UpdateState()
    {

    }

    public virtual void ExitState()
    {
        //player.anim.setBool(animBoolName, false);
    }

}
