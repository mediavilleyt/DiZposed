using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimState : AimBaseState
{
    public override void EnterState(AimStateManager aim)
    {
        aim.anim.SetBool("Aiming", true);
        aim.currentFov = aim.adsFov;
    }

    public override void UpdateState(AimStateManager aim)
    {
        if (Input.GetKeyUp(KeyCode.Mouse1)) aim.SwitchState(aim.hip);

        if (Input.GetKeyDown(KeyCode.R) && CD.Instance.clip != CD.Instance.maxClip && CD.Instance.ammo != 0)
        {
            aim.SwitchState(aim.reload);
        }

        if (CD.Instance.startReload == true)
        {
            aim.SwitchState(aim.reload);
        }
    }
}
