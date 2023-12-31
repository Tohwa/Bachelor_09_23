using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    #region Fields
    public StateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Animator Anim { get; private set; }

    [SerializeField]
    private GameObject playerBody;

    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private Transform playerSpawn;

    [SerializeField]
    private SoundRequestCollection requests;
    [SerializeField]
    private AudioData footSteps;
    [SerializeField]
    public PlayerData playerData;
    [SerializeField]
    private Shooting shootScript;

    [SerializeField]
    private float fireDelay;

    private float lastFireTime;
    public bool fire = false;
    public float healthPoints;

    private bool canRespawn;
    private float spawnDelay;

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

        healthPoints = playerData.healthPoints;

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

        if (fire && shootScript.canShoot)
        {
            shootScript.Shoot();
            StartCoroutine(shootScript.ShotDelay());
        }

        if(healthPoints <= 0)
        {
            healthPoints = 0;
            gameObject.SetActive(false);
        }

        if(!gameObject.activeSelf)
        {
            StartCoroutine(Respawn());

            if(canRespawn)
            {
                gameObject.transform.position = playerSpawn.transform.position;
                gameObject.SetActive(true);
            }
        }
    }

    private void FixedUpdate()
    {
        StateMachine.curPlayerState.PhysicsUpdate();
    }

    public void MovePlayer(float inputX, float inputY)
    {
        transform.Translate(inputX * playerData.moveSpeed * Time.deltaTime, 0, inputY * playerData.moveSpeed * Time.deltaTime);
    }

    public IEnumerator Respawn()
    {
        canRespawn = false;
        yield return new WaitForSeconds(spawnDelay);
        canRespawn = true;
    }
}
