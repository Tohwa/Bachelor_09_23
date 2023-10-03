using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform target;

    public NavMeshAgent Agent { get; private set; }
    public Rigidbody RB { get; private set; }

    public Animator anim { get; private set; }

    public StateMachine EnemyStateMachine { get; private set; }

    //public CarnivoreIdleState IdleState { get; private set; }
    //public CarnivorePatrolState PatrolState { get; private set; }
    //public CarnivoreHuntingState HuntingState { get; private set; }

    [SerializeField]
    private NPCData enemyData;


    private void Awake()
    {
        EnemyStateMachine = new StateMachine();

        //IdleState = new CarnivoreIdleState(this, EnemyStateMachine, enemyData);
        //PatrolState = new CarnivorePatrolState(this, EnemyStateMachine, enemyData);
        //HuntingState = new CarnivoreHuntingState(this, EnemyStateMachine, enemyData);

    }

    private void Start()
    {
        RB = GetComponent<Rigidbody>();

        anim = GetComponent<Animator>();

        //EnemyStateMachine.InitEnemyState(IdleState);
    }

    private void Update()
    {
        EnemyStateMachine.curEnemyState.LogicUpdate();
    }

    public void EnemyPatrol()
    {
        //if (transform.position == leftPatrol.position)
        //{
        //    Agent.SetDestination(rightPatrol.position);
        //    Agent.isStopped = false;
        //}
        //else
        //{
        //    Agent.SetDestination(leftPatrol.position);
        //    Agent.isStopped = false;
        //}
    }

    public void ChaseTarget()
    {
        Agent.SetDestination(target.position);
        Agent.isStopped = false;
    }
}
