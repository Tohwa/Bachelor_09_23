using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Transform target;
    private GameObject objectTarget;

    public NavMeshAgent Agent { get; private set; }
    public Rigidbody RB { get; private set; }

    public Animator anim { get; private set; }

    public StateMachine EnemyStateMachine { get; private set; }

    [SerializeField]
    private NPCData enemyData;


    private void Awake()
    {
        EnemyStateMachine = new StateMachine();
        objectTarget = GameObject.FindGameObjectWithTag("Player");
        target = objectTarget.transform;
    }

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
        Agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();        
    }

    private void Update()
    {
        //EnemyStateMachine.curEnemyState.LogicUpdate();

        ChaseTarget();
    }

    public void ChaseTarget()
    {
        Agent.SetDestination(target.position);
        Agent.isStopped = false;
    }
}
