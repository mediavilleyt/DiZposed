using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {
        movement.anim.SetBool("Crouching", true);
    }

    public override void UpdateState(MovementStateManager movement)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            ExitState(movement, movement.run);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if(movement.direction.magnitude < 0.1f)
            {
                ExitState(movement, movement.idle);
            }

            else
            {
                ExitState(movement, movement.walk);
            }
        }

        if (movement.yInput < 0.1f)
        {
            movement.currentMoveSpeed = movement.crouchBackSpeed;
        }

        else
        {
            movement.currentMoveSpeed = movement.crouchSpeed;
        }
    }

    void ExitState(MovementStateManager movement, MovementBaseState state)
    {
        movement.anim.SetBool("Crouching", false);
        movement.SwitchState(state);
    }
}
