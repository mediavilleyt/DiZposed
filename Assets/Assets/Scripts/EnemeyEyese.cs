using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyEyese : MonoBehaviour
{
    public GameObject player;
    public static bool CanSeePlayer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitInfo, 10f))
        {
            if(hitInfo.collider.tag == "Player")
            {
                CanSeePlayer = true;
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitInfo.distance, Color.green);
            }
            else
            {
                CanSeePlayer = false;
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitInfo.distance, Color.red);
            }
        }
    }
}
