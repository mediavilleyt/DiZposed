using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VanShoppingScript : MonoBehaviour
{
    public bool IsInVanRange;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(this.transform.position, player.transform.position) < 2)
        {
            IsInVanRange = true;
            Debug.Log("You are in range of ... THE VAN");
        }
        else
        {
            IsInVanRange = false;
        }

        if(Input.GetKeyUp(KeyCode.E) && IsInVanRange)
        {
            OpenVanShop();
        }
    }

    public void OpenVanShop()
    {
        Debug.Log("the Shop is open");
        SceneManager.LoadScene(0);  
    }
}
