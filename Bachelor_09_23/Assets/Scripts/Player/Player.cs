using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Player : MonoBehaviour
{
    #region Fields
    public StateMachine StateMachine { get; private set; }

    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }

    public PlayerInputHandler InputHandler { get; private set; }

    public Animator Anim { get; private set; }

    [SerializeField] private Rigidbody rb;

    [SerializeField]
    private PlayerData playerData;
    [SerializeField]
    private SoundRequestCollection requests;
    [SerializeField]
    private AudioData footSteps;

    public Vector2 input;
    #endregion

    private void Awake()
    {
        StateMachine = new StateMachine();

        IdleState = new PlayerIdleState(this, StateMachine, playerData);
        MoveState = new PlayerMoveState(this, StateMachine, playerData);
    }

    private void Start()
    {
        Anim = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();

        StateMachine.InitPlayerState(IdleState);
    }

    private void Update()
    {

        input = InputHandler.MovementInput;

        StateMachine.curPlayerState.LogicUpdate();

        if (StateMachine.curPlayerState == MoveState)
        {
            if (Time.frameCount % 60 == 0)
            {
                requests.Add(SoundRequest.Request(footSteps));
            }
        }
    }

    private void FixedUpdate()
    {
        StateMachine.curPlayerState.PhysicsUpdate();
    }

    public void MovePlayer(float inputX, float inputY)
    {
        transform.Translate(inputX * playerData.moveSpeed *Time.deltaTime, 0, inputY * playerData.moveSpeed * Time.deltaTime);
    }
}
