using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class WeaponSwitch : MonoBehaviour
{
    TwoBoneIKConstraint secondIK;
    TwoBoneIKConstraint primaryIK;

    GameObject secondary;
    GameObject primary;

    primaryType primaryWeapon;

    public GameObject pistolModel;
    public GameObject rifleModel;
    public GameObject shotgunModel;

    public TwoBoneIKConstraint pistolIK;
    public TwoBoneIKConstraint rifleIK;
    public TwoBoneIKConstraint shotgunIK;

    WhatSelected selected;

    private void Start()
    {
        switch (CD.Instance.primaryInt)
        {
            case 0: primaryWeapon = primaryType.rifle;
                break;
            case 1: primaryWeapon = primaryType.shotgun;
                break;
        }

        selected = WhatSelected.secondary;

        switch (primaryWeapon)
        {
            case primaryType.shotgun:
                primary = shotgunModel;
                primaryIK = shotgunIK;
                break;

            case primaryType.rifle:
                primary = rifleModel; 
                primaryIK = rifleIK;
                break;
        }

        secondary = pistolModel;
        secondIK = pistolIK;

        SwitchWeapons();
    }

    private void Update()
    {
        if (CD.Instance.isPaused) return;

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchWeapons();
        }
    }

    public void SwitchWeapons()
    {
        switch (selected)
        {
            case WhatSelected.secondary:
                selected = WhatSelected.primary;
                secondary.SetActive(false);
                secondIK.weight = 0;
                primary.SetActive(true);
                primaryIK.weight = 1;
                break;
            case WhatSelected.primary:
                selected = WhatSelected.secondary;
                primary.SetActive(false);
                primaryIK.weight = 0;
                secondary.SetActive(true);
                secondIK.weight = 1;
                break;
        }
    }

    public enum WhatSelected
    {
        secondary,
        primary
    }

    public enum primaryType
    {
        shotgun,
        rifle
    }
}
