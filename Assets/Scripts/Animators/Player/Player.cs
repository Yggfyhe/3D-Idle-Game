using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
   [field:SerializeField] public PlayerSO Data {  get; private set; }  
   [field:Header("애니메이션")]
   [field: SerializeField] public PlayerAnimationData AnimationData {  get; private set; }

    public Animator Animator {  get; private set; }
    public PlayerController Input { get; private set; }
    public CharacterController Controller {  get; private set; }
    public ForceReceiver ForceReceiver { get; private set; }

    private PlayerStateMachine stateMachine;

    private void Awake()
    {
        AnimationData.Initialize();
        Animator = GetComponentInChildren<Animator>();
        Input = GetComponent<PlayerController>();
        Controller = GetComponent<CharacterController>();
        ForceReceiver = GetComponent<ForceReceiver>();


        stateMachine = new PlayerStateMachine(this);
        stateMachine.ChangeState(stateMachine.IdleState);
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        stateMachine.HandleInput();
        stateMachine.Update();
    }

    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }










}
