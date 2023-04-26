using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wormEnemy : MonoBehaviour
{
    [SerializeField] private float leftCap;
    [SerializeField] protected float rightCap;
    [SerializeField] private float way;
    [SerializeField] private float pigrun;
    public bool facingLeft = true;

    [SerializeField] private LayerMask ground;

    private enum State { idle, run }
    private State state_f = State.idle;

    private Rigidbody2D rb;
    private Collider2D coll;

    private Animator anim;

    public float speedEnemy;
    public Transform target;
    public float minimunDistance;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Moveworm();
        AiEnemy();
    }

    //Movement worm
    private void Moveworm()
    {
        if (facingLeft)
        {

            if (transform.position.x > leftCap)
            {
                if (transform.localScale.x == -1)
                {
                    transform.localScale = new Vector3(1, 1);
                }
                if (coll.IsTouchingLayers(ground))
                {
                    rb.velocity = new Vector2(-way, pigrun);
                    state_f = State.run;
                }
            }
            else
            {
                facingLeft = false;
            }

        }
        else
        {
            if (transform.position.x < rightCap)
            {
                if (transform.localScale.x == 1)
                {
                    transform.localScale = new Vector3(-1, 1);
                }

                if (coll.IsTouchingLayers(ground))
                {
                    rb.velocity = new Vector2(way, pigrun);
                    state_f = State.run;
                }
            }
            else
            {
                facingLeft = true;
            }

        }
    }

    //Enemy traget Player
    private void AiEnemy()
    {
        if (Vector2.Distance(transform.position, target.position) > minimunDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speedEnemy * Time.deltaTime);
        }
    }
}
