using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaseController : MonoBehaviour
{
    public bridEnemy[] enemyArray;

    //Play Sound and Check player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            foreach(bridEnemy enemy in enemyArray)
            {
                
                enemy.chase = true;
            }
        }
    }
    //Check if a player is out of range.
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (bridEnemy enemy in enemyArray)
            {
                enemy.chase = false;
                
            }
        }
    }


    
}
