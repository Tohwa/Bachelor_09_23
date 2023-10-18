using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEditor;
using UnityEngine;


public class StateMachine
{
    public BaseState curPlayerState;
    public BaseState curEnemyState;
    public BaseState curAnimalState;
    public BaseState curGameState;

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
        curAnimalState = _startState;
        curAnimalState.EnterState();
    }

    public void InitGameState(BaseState _startState)
    {
        curGameState = _startState;
        curGameState.EnterState();
    }

    public void ChangePlayerState(BaseState _newState)
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
        curAnimalState.ExitState();
        curAnimalState = _newState;
        curAnimalState.EnterState();
    }

    public void ChangeGameState(BaseState _newState)
    {
        curGameState.ExitState();
        curGameState = _newState;
        curGameState.EnterState();
    }
}
