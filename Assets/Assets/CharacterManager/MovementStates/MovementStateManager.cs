using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Unity.VisualScripting;
using UnityEngine;

public class MovementStateManager : MonoBehaviour
{
    public float currentMoveSpeed = 3;
    public float walkSpeed = 3;
    public float walkBackSpeed = 2;
    public float runSpeed = 7;
    public float runBackSpeed = 5;
    public float crouchSpeed = 2;
    public float crouchBackSpeed = 1;

    [HideInInspector]
    public Vector3 direction;
    public float xInput;
    public float yInput;
    CharacterController controller;

    public float groundYOffset;
    public LayerMask groundMask;
    Vector3 spherePos;

    public float gravity = -9.81f;
    Vector3 velocity;

    MovementBaseState currentState;

    public IdleState idle = new  IdleState();
    public WalkState walk = new WalkState();
    public CrouchState crouch = new CrouchState();
    public RunState run = new RunState();

    [HideInInspector]
    public Animator anim;

    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
        SwitchState(idle);
    }

    void Update()
    {
        if (CD.Instance.isPaused) return;

        GetDirectionAndMove();
        Gravity();

        anim.SetFloat("hzInput", xInput);
        anim.SetFloat("vInput", yInput);

        currentState.UpdateState(this);
    }

    public void SwitchState(MovementBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    void GetDirectionAndMove()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        direction = transform.forward * yInput + transform.right * xInput;

        controller.Move(direction * currentMoveSpeed * Time.deltaTime);
    }

    bool IsGrounded()
    {
        spherePos = new Vector3(transform.position.x, transform.position.y - groundYOffset, transform.position.z);
        if (Physics.CheckSphere(spherePos, controller.radius - 0.05f, groundMask)) return true;
        return false;
    }

    void Gravity()
    {
        if (!IsGrounded()) velocity.y += gravity * Time.deltaTime;
        else if (velocity.y < 0) velocity.y = -2;

        direction = transform.forward * yInput + transform.right * xInput;

        controller.Move(velocity * Time.deltaTime);
    }
}
