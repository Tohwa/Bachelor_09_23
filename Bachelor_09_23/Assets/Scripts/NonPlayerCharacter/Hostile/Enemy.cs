using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public GameObject objectTarget;

    public NavMeshAgent Agent { get; private set; }
    public Rigidbody RB { get; private set; }

    public Animator anim { get; private set; }

    public ChaseState ChaseState { get; private set; }  

    public AttackState AttackState { get; private set; }

    public StateMachine EnemyStateMachine { get; private set; }

    [SerializeField]
    private NPCData enemyData;


    private void Awake()
    {
        EnemyStateMachine = new StateMachine();

        ChaseState = new ChaseState(this, EnemyStateMachine, enemyData);
        AttackState = new AttackState(this, EnemyStateMachine, enemyData);
    }

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
        Agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        EnemyStateMachine.InitEnemyState(ChaseState);
    }

    private void Update()
    {
        EnemyStateMachine.curEnemyState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        EnemyStateMachine.curEnemyState.PhysicsUpdate();
    }

    public void ChaseTarget()
    {
        Agent.SetDestination(target.position);
        Agent.isStopped = false;
    }
}
