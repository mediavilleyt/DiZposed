using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HipFireState : AimBaseState
{
    public override void EnterState(AimStateManager aim)
    {
        aim.anim.SetBool("Reloading", false);
        CD.Instance.isReloading = false;
        aim.anim.SetBool("Aiming", false);
        aim.currentFov = aim.hipFov;
    }

    public override void UpdateState(AimStateManager aim)
    {
        if (Input.GetKey(KeyCode.Mouse1)) aim.SwitchState(aim.aim);

        if (Input.GetKeyDown(KeyCode.R) && CD.Instance.clip != CD.Instance.maxClip && CD.Instance.ammo != 0)
        {
            aim.SwitchState(aim.reload);
        }

        if(CD.Instance.startReload == true)
        {
            aim.SwitchState(aim.reload);
        }
    }
}
