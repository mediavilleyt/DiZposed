using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingForCandy : MonoBehaviour
{
    private Vector3 Pos;

    // Start is called before the first frame update
    void Start()
    {
        Pos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = Input.mousePosition;
        targetPos = Camera.main.ScreenToWorldPoint(targetPos);

        CD.Instance.MousePos = targetPos;

        float y = Pos.y;
        float x = Pos.x;

        if (CD.Instance.MousePos.x <= x && CD.Instance.MousePos.y <= y)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if(this.gameObject.tag == "Bullets")
                {
                    CD.Instance.ammo += 20;
                }
            }
        }
    }
}
