using System.Transactions;
using UnityEngine;
using UnityEngine.Audio;

public class CD //CD stands for 'Central Data'
{
    public Transform aimPos; 
    public GameObject whatHit;
    public AudioMixer Music;
    public AudioMixer Effects;

    public bool isReloading;
    public bool startReload;

    public float ammo;
    public float clip;
    public float maxClip;

    public int primaryInt;

    public Transform barrelPos;

    public bool isPaused = false;

    public int HP;

    public Vector3 MousePos;

    public void PauseGame(PauseTypes type, bool a)
    {
        switch (type)
        {
            case PauseTypes.sP:
                if (a)
                {
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                }
                else
                {
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                }
                break;
            case PauseTypes.mP:
                if (a)
                {
                    Time.timeScale = 1f;
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    isPaused = false;
                }
                else
                {
                    Time.timeScale = 0f;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    isPaused = true;
                }
                break;
        }
    }

    private static CD instance;
    public static CD Instance
    {
        get
        {
            if (instance == null) instance = new();
            return instance;
        }
    }
    public CD() { }

    public enum PauseTypes
    {
        sP, //Small Pause
        mP, //Medium Pause
        bP  //Big Pause
    }
}
