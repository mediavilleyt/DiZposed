using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starts : MonoBehaviour
{
    void Start()
    {
        CD.Instance.PauseGame(CD.PauseTypes.sP, true);
        /*This line executes the "small pause".
         * small pause means that when true the game will be running 
         * and the mouse gets locked and becomes invisible.*/
    }
}
