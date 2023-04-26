using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtk : MonoBehaviour
{
    public Transform target;
    public Animation eniAni;
    int atk;
    void enemyAtk()
    {
        if ((target.position - transform.position).magnitude < 4)
        {
            switch (atk)
            {
                case 0:
                    eniAni.Play("Enemy_Atk");
                    break;
            }
        }
    }
}
