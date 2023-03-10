using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.UIElements;

public class WeaponManager : MonoBehaviour
{
    public float fireRate;
    float fireRateTimer;
    public bool semiAuto;
    public bool isReloading = false;
    public GameObject muzzleFlash;
    public AudioSource gunShot;
    public AudioSource reloadSound;

    public MultiAimConstraint handAim;

    public Transform barrelPos;

    public int ammo;
    int clip;
    public int clipSize;

    void Start()
    {
        clip = clipSize;
        ammo -= clip;
        fireRateTimer = fireRate;
        CD.Instance.barrelPos = barrelPos;
    }

    void Update()
    {
        if (CD.Instance.isPaused) return;

        if (CD.Instance.isReloading) isReloading = CD.Instance.isReloading;
        if (ShouldFire()) Fire();
        if (isReloading) Reloading();

        if(Input.GetKeyDown(KeyCode.Mouse0) && clip == 0 && ammo >= clipSize)
        {
            CD.Instance.startReload = true;
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            handAim.weight = 1f;
        }

        else
        {
            handAim.weight = 0f;
        }

        CD.Instance.ammo = ammo;
        CD.Instance.clip = clip;
        CD.Instance.maxClip = clipSize;
    }

    bool ShouldFire()
    {
        fireRateTimer += Time.deltaTime;
        if (fireRateTimer < fireRate) return false;
        if (clip == 0) return false;
        if (isReloading) return false;
        if (semiAuto && Input.GetKeyDown(KeyCode.Mouse0)) return true;
        if (!semiAuto && Input.GetKey(KeyCode.Mouse0)) return true;
        return false;
    }

    void Fire()
    {
        fireRateTimer = 0;
        muzzleFlash.SetActive(true);
        gunShot.Play();
        clip--;
        Invoke("AfterFire", 0.1f);
    }

    void AfterFire()
    {
        muzzleFlash.SetActive(false);
    }

    void Reloading()
    {
        reloadSound.Play();

        if (!CD.Instance.isReloading)
        {
            if(ammo >= clipSize)
            {
                clip = clipSize;
                ammo -= clipSize;
            }

            Debug.Log("ReloadFinished!");
            isReloading = false;
        }
    }
}
