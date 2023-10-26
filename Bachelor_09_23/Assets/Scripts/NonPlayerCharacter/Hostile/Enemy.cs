using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.EventSystems.EventTrigger;

public class Enemy : MonoBehaviour
{
    public GameObject activeTarget;
    public GameObject prevTarget;

    public NavMeshAgent Agent { get; private set; }
    public Rigidbody RB { get; private set; }
    public Animator Anim { get; private set; }

    public StateMachine EnemyStateMachine { get; private set; }

    public ChaseState ChaseState { get; private set; }
    public AttackState AttackState { get; private set; }
    public LocateTargetState LocateState { get; private set; }

    [SerializeField]
    private NPCData enemyData;
    [SerializeField]
    public NeutralNPC sheepData;
    [SerializeField]
    public Fence fenceData;
    //[SerializeField]
    //public Player playerData;

    public GameObject fence;

    public bool canAttack = true;

    private float attackDamage;
    private float attackDelay;

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

        Agent.speed = enemyData.moveSpeed;
        Agent.stoppingDistance = enemyData.stopDistance;

        attackDamage = enemyData.attackDamage;
        attackDelay = enemyData.attackDelay;
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
        if (activeTarget == null)
        {
            if (gameObject.CompareTag("Goat"))
            {
                activeTarget = GameObject.FindGameObjectWithTag("Player");
            }
            else if (gameObject.CompareTag("Boar") || gameObject.CompareTag("Wolf"))
            {
                if (prevTarget == null)
                {
                    FindClosestFence();
                }
                else if (!fence.activeSelf)
                {
                    FindClosestSheep();
                }                
            }
        }
    }

    private void FindClosestFence()
    {
        float firstDistance;
        float secDistance;

        if(GameManager.Instance.fenceTargets.Count != 0)
        {
            firstDistance = CalcTargetDistance(gameObject.transform.position, GameManager.Instance.fenceTargets.First().transform.position);

            activeTarget = GameManager.Instance.fenceTargets.First();

            for (int x = 0; x < GameManager.Instance.fenceTargets.Count; x++)
            {
                secDistance = CalcTargetDistance(gameObject.transform.position, GameManager.Instance.fenceTargets[x].transform.position);

                if (firstDistance > secDistance)
                {
                    prevTarget = GameManager.Instance.fenceTargets[x];
                    activeTarget = GameManager.Instance.fenceTargets[x];
                    firstDistance = secDistance;
                }

            }

            //GameManager.Instance.fenceTargets.Remove(objectTarget);
            //GameManager.Instance.sheepTargets.Clear();
        }
        else
        {
            Debug.Log("no more fences available");
            return;
        }
    }

    private void FindClosestSheep()
    {
        float firstDistance;
        float secDistance;

        if(GameManager.Instance.sheepTargets.Count != 0)
        {
            firstDistance = CalcTargetDistance(gameObject.transform.position, GameManager.Instance.sheepTargets.First().transform.position);

            activeTarget = GameManager.Instance.sheepTargets.First();

            for (int x = 0; x < GameManager.Instance.sheepTargets.Count; x++)
            {
                secDistance = CalcTargetDistance(gameObject.transform.position, GameManager.Instance.sheepTargets[x].transform.position);

                if (firstDistance > secDistance)
                {
                    activeTarget = GameManager.Instance.sheepTargets[x];
                    firstDistance = secDistance;
                }

            }

            //GameManager.Instance.sheepTargets.Remove(objectTarget);
            //GameManager.Instance.sheepTargets.Clear();
        }
        else
        {
            Debug.Log("no more sheep available");
            return;
        }
    }

    private float CalcTargetDistance(Vector3 firstTransform, Vector3 secTransform)
    {
        return Vector3.Distance(firstTransform, secTransform);
    }

    public void DisableTarget()
    {
        activeTarget.SetActive(false);
    }
    public IEnumerator AttackDelay()
    {
        if (activeTarget.CompareTag("Fence"))
        {
            fenceData.durability -= attackDamage;
        }
        else if (activeTarget.CompareTag("Sheep"))
        {
            sheepData.healthPoints -= attackDamage;
        }
        //else if (activeTarget.CompareTag("Player"))
        //{
        //    playerData.healthPoints -= attackDamage;
        //}

        canAttack = false;
        yield return new WaitForSeconds(attackDelay);
        canAttack = true;
    }
}
