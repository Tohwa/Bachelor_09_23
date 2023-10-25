using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NeutralNPC : MonoBehaviour
{
    public StateMachine SheepStateMachine { get; private set; }

    public CozyState CozyState { get; private set; }
    public AlarmedState AlarmedState { get; private set; }
    public EscapeState EscapeState { get; private set; }
    public ReturnHomeState ReturnState { get; private set; }

    public Rigidbody RB { get; private set; }
    public Animator Anim { get; private set; }
    public NavMeshAgent Agent { get; private set; }

    [SerializeField]
    public NPCData sheepData;
    [SerializeField]
    public AggroTrigger trigger;

    public GameObject aggroTrigger;

    public float healthPoints;

    private void Awake()
    {
        SheepStateMachine = new StateMachine();

        CozyState = new CozyState(this, SheepStateMachine, sheepData);
        AlarmedState = new AlarmedState(this, SheepStateMachine, sheepData);
        EscapeState = new EscapeState(this, SheepStateMachine, sheepData);
        ReturnState = new ReturnHomeState(this, SheepStateMachine, sheepData);
    }

    private void Start()
    {
        RB = GetComponent<Rigidbody>();
        Agent = GetComponent<NavMeshAgent>();
        Anim = GetComponent<Animator>();

        healthPoints = sheepData.healthPoints;

        if(GameManager.Instance.fenceTargets.Count != 0)
        {
            SheepStateMachine.InitNPCState(CozyState);
        }
        else
        {
            SheepStateMachine.InitNPCState(AlarmedState);
        }
    }

    private void Update()
    {
        SheepStateMachine.curAnimalState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        SheepStateMachine.curAnimalState.PhysicsUpdate();
    }
}
