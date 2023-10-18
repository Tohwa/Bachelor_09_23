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

    public ChaseState ChaseState { get; private set; }

    public AttackState AttackState { get; private set; }

    public LocateTargetState LocateState { get; private set; }


    public StateMachine EnemyStateMachine { get; private set; }

    [SerializeField]
    private NPCData enemyData;
    [SerializeField]
    public List<GameObject> potFenceTargets = new();
    [SerializeField]
    public List<GameObject> potSheepTargets = new();

    private Array foundFences;
    private Array foundSheep;


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

        foundFences = GameObject.FindGameObjectsWithTag("Fence");

        foreach (GameObject obj in foundFences)
        {
            potFenceTargets.Add(obj);
        }

        foundSheep = GameObject.FindGameObjectsWithTag("Sheep");

        foreach (GameObject obj in foundSheep)
        {
            potSheepTargets.Add(obj);
        }

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
            else if (gameObject.CompareTag("Wolf") || gameObject.CompareTag("Boar"))
            {
                FindClosestFence();

                if (potFenceTargets.Count == 0 && potSheepTargets.Count != 0)
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

        firstDistance = CalcTargetDistance(gameObject.transform.position, potFenceTargets.First().transform.position);

        objectTarget = potFenceTargets.First();

        for (int x = 0; x < potFenceTargets.Count; x++)
        {
            secDistance = CalcTargetDistance(gameObject.transform.position, potFenceTargets[x].transform.position);

            if (firstDistance > secDistance)
            {
                objectTarget = potFenceTargets[x];
                firstDistance = secDistance;
            }

        }

        potFenceTargets.Remove(objectTarget);
        Debug.Log($"{objectTarget} has been removed from the Fence List");
    }

    private void FindClosestSheep()
    {
        float firstDistance;
        float secDistance;

        firstDistance = CalcTargetDistance(gameObject.transform.position, potSheepTargets.First().transform.position);

        objectTarget = potSheepTargets.First();

        for (int x = 0; x < potSheepTargets.Count; x++)
        {
            secDistance = CalcTargetDistance(gameObject.transform.position, potSheepTargets[x].transform.position);

            if (firstDistance > secDistance)
            {
                objectTarget = potSheepTargets[x];
                firstDistance = secDistance;
            }

        }

        potSheepTargets.Remove(objectTarget);
        Debug.Log($"{objectTarget} has been removed from the Sheep List");
    }

    private float CalcTargetDistance(Vector3 firstTransform, Vector3 secTransform)
    {
        return Vector3.Distance(firstTransform, secTransform);
    }

    public void DisableTarget()
    {
        objectTarget.SetActive(false);
    }
}
