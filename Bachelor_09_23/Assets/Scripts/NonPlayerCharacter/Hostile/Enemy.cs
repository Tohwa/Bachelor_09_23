using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject objectTarget;

    public NavMeshAgent Agent { get; private set; }
    public Rigidbody RB { get; private set; }

    public Animator Anim { get; private set; }

    public ChaseState ChaseState { get; private set; }

    public AttackState AttackState { get; private set; }

    public LocateTargetState LocateState { get; private set; }


    public StateMachine EnemyStateMachine { get; private set; }

    [SerializeField]
    private NPCData enemyData;


    private void Awake()
    {
        EnemyStateMachine = new StateMachine();

        ChaseState = new ChaseState(this, EnemyStateMachine, enemyData);
        AttackState = new AttackState(this, EnemyStateMachine, enemyData);
        LocateState = new LocateTargetState(this, EnemyStateMachine, enemyData);
    }

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
        Agent = GetComponent<NavMeshAgent>();
        Anim = GetComponent<Animator>();

        EnemyStateMachine.InitEnemyState(LocateState);
    }

    private void Update()
    {
        EnemyStateMachine.curEnemyState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        EnemyStateMachine.curEnemyState.PhysicsUpdate();
    }

    public void ChaseTarget(GameObject _target)
    {
        Agent.SetDestination(_target.transform.position);
        Agent.isStopped = false;
    }

    public void FindTarget()
    {
        if (objectTarget == null)
        {
            if (gameObject.CompareTag("Goat"))
            {
                objectTarget = GameObject.FindGameObjectWithTag("Player");
            }
            else if(gameObject.CompareTag("Wolf") || gameObject.CompareTag("Boar"))
            {
                objectTarget = GameObject.FindGameObjectWithTag("Fence");

                if (objectTarget == null)
                {
                    objectTarget = GameObject.FindGameObjectWithTag("Sheep");
                }
            }
        }
    }

    public void DestroyTarget()
    {
        Destroy(objectTarget);
        Debug.Log("Target has been Destroyed!");
    }
}
