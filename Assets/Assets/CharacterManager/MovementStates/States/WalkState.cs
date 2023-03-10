using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WalkState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {
        movement.anim.SetBool("Walking", true);
    }

    public override void UpdateState(MovementStateManager movement)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            ExitState(movement, movement.run);
        }

        else if (Input.GetKeyDown(KeyCode.C))
        {
            ExitState(movement, movement.crouch);
        }

        else if(movement.direction.magnitude < 0.1f)
        {
            ExitState(movement, movement.idle);
        }

        if(movement.yInput < 0.1f)
        {
            movement.currentMoveSpeed = movement.walkBackSpeed; 
        }

        else
        {
            movement.currentMoveSpeed = movement.walkSpeed;
        }
    }

    void ExitState(MovementStateManager movement, MovementBaseState state)
    {
        movement.anim.SetBool("Walking", false);
        movement.SwitchState(state);
    }   
}
