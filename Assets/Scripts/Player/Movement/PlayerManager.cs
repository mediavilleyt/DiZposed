using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    GameObject Player;

    [HideInInspector] public MouseLook Look;
    [HideInInspector] public PlayerMovement Move;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        Look = Player.GetComponent<MouseLook>();
        Move = Player.GetComponent<PlayerMovement>();

        Data.Instance.Player = this;
    }
}
