using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject objectTarget;

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
    public NPCData sheepData;
    [SerializeField]
    public Fence fenceData;
    [SerializeField]
    public PlayerData playerData;

    public float targetHealth;

    private bool canAttack;

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
            else if (gameObject.CompareTag("Wolf") || gameObject.CompareTag("Boar"))
            {
                if (GameManager.Instance.fenceTargets.Count != 0)
                {
                    FindClosestFence();
                }
                else
                {
                    if (GameManager.Instance.sheepTargets.Count != 0)
                    {
                        FindClosestSheep();
                    }
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

            objectTarget = GameManager.Instance.fenceTargets.First();

            for (int x = 0; x < GameManager.Instance.fenceTargets.Count; x++)
            {
                secDistance = CalcTargetDistance(gameObject.transform.position, GameManager.Instance.fenceTargets[x].transform.position);

                if (firstDistance > secDistance)
                {
                    objectTarget = GameManager.Instance.fenceTargets[x];
                    firstDistance = secDistance;
                }

            }

            GameManager.Instance.fenceTargets.Remove(objectTarget);
            Debug.Log($"{objectTarget} has been removed from the Fence List");            
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

            objectTarget = GameManager.Instance.sheepTargets.First();

            for (int x = 0; x < GameManager.Instance.sheepTargets.Count; x++)
            {
                secDistance = CalcTargetDistance(gameObject.transform.position, GameManager.Instance.sheepTargets[x].transform.position);

                if (firstDistance > secDistance)
                {
                    objectTarget = GameManager.Instance.sheepTargets[x];
                    firstDistance = secDistance;
                }

            }

            GameManager.Instance.sheepTargets.Remove(objectTarget);
            Debug.Log($"{objectTarget} has been removed from the Sheep List");
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
        objectTarget.SetActive(false);
    }

    public void AttackTarget()
    {
        if(canAttack)
        {
            if (objectTarget.CompareTag("Fence"))
            {   
                fenceData.fenceDurability -= enemyData.attackDamage;
                StartCoroutine(AttackDelay());
            }
            else if (objectTarget.CompareTag("Sheep"))
            {
                sheepData.healthPoints -= enemyData.attackDamage;
                StartCoroutine(AttackDelay());
            }
            else if (objectTarget.CompareTag("Player"))
            {
                playerData.healthPoints -= enemyData.attackDamage;
                StartCoroutine(AttackDelay());
            }
            
        }
    }

    public IEnumerator AttackDelay()
    {
        canAttack = false;
        yield return new WaitForSeconds(enemyData.attackDelay);
        canAttack = true;
    }
}
