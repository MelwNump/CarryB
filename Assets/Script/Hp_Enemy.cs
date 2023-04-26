using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Hp_Enemy : MonoBehaviour
{
    public GameObject soul;
    public GameObject enemy;
    [SerializeField] private GameObject expo;

    private void Start()
    {
        soul.SetActive(false);
        enemy.SetActive(true);
    }

    //if Player Take Damage and die
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "DmgPlayer")
        {
            soul.SetActive(true);
            Instantiate(expo,transform.position , Quaternion.identity);
            var cory = Instantiate(expo);
            Destroy(cory,1.5f);
            Destroy(enemy);
        }
    }
}
