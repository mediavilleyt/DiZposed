using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemey : MonoBehaviour
{
    private GameObject player;
    public int Range;
    public int Speed;

    public float TotalTime = 2;
    public float Timer;

    public int Damage;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Damage = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemeyEyese.CanSeePlayer == true & Vector3.Distance(this.transform.position, player.transform.position) > 1 && Vector3.Distance(this.transform.position, player.transform.position) <= 10)
        {
            Speed = 5;
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z), Speed * Time.deltaTime);
        }
        else
        {
            Speed = 0;
        }

        if(Vector3.Distance(this.transform.position, player.transform.position) <= 1)
        {
            Attack();
        }
    }

    public void Attack()
    {
        Timer += Time.deltaTime;

        if(Timer >= TotalTime)
        {
            CD.Instance.HP -= Damage;

            Timer = 0;
        }
    }
}
