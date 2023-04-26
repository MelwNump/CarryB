using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wormenimy : MonoBehaviour
{
    public float speed;
    private GameObject player;

    public bool chase = false;
    public Transform startingPoint;

    public Animator playerAni;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (player == null)
            return;

        if (chase == true)
        {
            Chase();
        }
        else
            ReturnStartPoint();

        Flip();
    }
    // Move Enemy go to Star point
    private void ReturnStartPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, speed * Time.deltaTime);
    }
    //Move Traget Player
    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        playerAni.Play("atk");
    }
    //Flip Enemy R,L
    private void Flip()
    {
        if (transform.position.x > player.transform.position.x)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else
            transform.rotation = Quaternion.Euler(0, 180, 0);
    }
}
