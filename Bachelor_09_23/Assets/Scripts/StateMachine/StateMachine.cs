using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;


public class StateMachine
{
    public BaseState curPlayerState;
    public BaseState curEnemyState;
    public BaseState curNPCState;

    public void InitPlayerState(BaseState _startState)
    {
        curPlayerState = _startState;
        curPlayerState.EnterState();
    }

    public void InitEnemyState(BaseState _startState)
    {
        curEnemyState = _startState;
        curEnemyState.EnterState();
    }

    public void InitNPCState(BaseState _startState)
    {
        curNPCState = _startState;
        curNPCState.EnterState();
    }

    public void ChangeState(BaseState _newState)
    {
        curPlayerState.ExitState();
        curPlayerState = _newState;
        curPlayerState.EnterState();
    }

    public void ChangeEnemyState(BaseState _newState)
    {
        curEnemyState.ExitState();
        curEnemyState = _newState;
        curEnemyState.EnterState();
    }

    public void ChangeNPCState(BaseState _newState)
    {
        curNPCState.ExitState();
        curNPCState = _newState;
        curNPCState.EnterState();
    }
}
