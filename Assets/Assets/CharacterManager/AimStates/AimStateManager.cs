using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows.WebCam;

public class AimStateManager : MonoBehaviour
{
    AimBaseState currentState;
    public HipFireState hip = new HipFireState();
    public AimState aim = new AimState();
    public ReloadState reload = new ReloadState();

    public float mouseSense = 1f;
    float xAxis;
    float yAxis;
    public Transform camFollowPos;

    [HideInInspector]
    public Animator anim;

    [HideInInspector]
    public CinemachineVirtualCamera vCam;
    public float adsFov = 40;
    [HideInInspector] public float hipFov;
    [HideInInspector] public float currentFov;
    public float fovSmoothSpeed;

    public Transform aimPos;
    public float aimSmoothSpeed = 20;
    public LayerMask aimMask;

    private void Start()
    {
        vCam = GetComponentInChildren<CinemachineVirtualCamera>();
        hipFov = vCam.m_Lens.FieldOfView;
        anim = GetComponent<Animator>();
        SwitchState(hip);
    }

    void Update()
    {
        if (CD.Instance.isPaused) return;

        xAxis += Input.GetAxisRaw("Mouse X") * mouseSense;
        yAxis -= Input.GetAxisRaw("Mouse Y") * mouseSense;
        yAxis = Mathf.Clamp(yAxis, -80f, 80f);

        vCam.m_Lens.FieldOfView = Mathf.Lerp(vCam.m_Lens.FieldOfView, currentFov, fovSmoothSpeed * Time.deltaTime);

        if (Physics.Raycast(Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2)), out RaycastHit hit, Mathf.Infinity))
        {
            aimPos.position = Vector3.Lerp(aimPos.position, hit.point, aimSmoothSpeed * Time.deltaTime); 
            CD.Instance.aimPos = aimPos;

            if (Input.GetKey(KeyCode.Mouse0)) 
            {
                if (Physics.Raycast(CD.Instance.barrelPos.transform.position, CD.Instance.barrelPos.transform.forward, out RaycastHit hit2, Mathf.Infinity))
                {
                    CD.Instance.whatHit = hit2.transform.gameObject;
                }
            }
        }

        currentState.UpdateState(this);
    }

    private void LateUpdate()
    {
        camFollowPos.localEulerAngles =  new Vector3(yAxis, camFollowPos.localEulerAngles.y, camFollowPos.localEulerAngles.z);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, xAxis, transform.eulerAngles.z);
    }

    public void SwitchState(AimBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
}
