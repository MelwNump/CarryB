using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridEnemy : MonoBehaviour
{
    public float speed;
    private GameObject player;

    public bool chase = false;
    public Transform startingPoint;

    public Animator playerAni;
    //public AudioSource bridAudi;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    private void Update()
    {
        if (player == null) 
            return;

        if(chase == true)
        {
            //bridAudi.Play();
            Chase();
        }
        else
            ReturnStartPoint();

        Flip();
    }

    private void ReturnStartPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position,startingPoint.position, speed * Time.deltaTime);
    }
    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        
        //playerAni.Play("atks");
    }
    private void Flip()
    {
        if (transform.position.x > player.transform.position.x)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else
            transform.rotation = Quaternion.Euler(0, 180,0);
    }
}
