using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadState : AimBaseState
{
    public override void EnterState(AimStateManager aim)
    {
        CD.Instance.startReload = false;
        CD.Instance.isReloading = true;
        aim.anim.SetBool("Hip", false);
        aim.anim.SetBool("Reloading", true);
    }

    public override void UpdateState(AimStateManager aim)
    {
        aim.anim.SetBool("Hip", true);

        Debug.Log(aim.anim.GetCurrentAnimatorStateInfo(0).normalizedTime % 1);

        if (aim.anim.GetCurrentAnimatorStateInfo(0).normalizedTime % 1 > 0.8f)
        {
            aim.SwitchState(aim.hip);
        }
    }
}
