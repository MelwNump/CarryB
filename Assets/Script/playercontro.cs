using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playercontro : MonoBehaviour
{
    public AudioSource runSoun;
    public AudioSource jumpSound;
    public AudioSource fallingSound;
   
    public float Lspeed;
    public float Rspeed;
    public float jump;

    [SerializeField] private Animator anim;
    [SerializeField] private Collider2D cooll;
    [SerializeField] private LayerMask ground;
    [SerializeField] private float hurtnum;
    [SerializeField] private Rigidbody2D rb;

    private enum State { idle , run , jump , falling , hurt}
    private State state = State.idle;
    
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(state != State.hurt)
        {
            Movement();
        }
        AnimationState();
        anim.SetInteger("state" , (int)state);
    }

    //Hurt 
    private void OnCollisionEnter2D(Collision2D collision)
    {
       bridEnemy birds = collision.gameObject.GetComponent<bridEnemy>();
        if(collision.gameObject.tag == "HitBoxEnemy")
        {
            state = State.hurt;
            if (collision.gameObject.transform.position.x > transform.position.x)
            {
                rb.velocity = new Vector2(-hurtnum, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(hurtnum, rb.velocity.y);
            }
            
        }
    }

    //Movement Player and Sound Player
    void Movement ()
    {
        float hDirection = Input.GetAxis("Horizontal");
        
        if (hDirection < 0)
        {
            rb.velocity = new Vector2(-Lspeed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
           
        }
        else if (hDirection > 0)
        {
            rb.velocity = new Vector2(Rspeed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
            
        }
        else
        {
            runSoun.Play();
        }

        if (Input.GetButtonDown("Jump") && cooll.IsTouchingLayers(ground))
        {
            Jump();
            jumpSound.Play();
            runSoun.Stop();
        }
    }

    //Jump
    void Jump ()
    {
        rb.velocity = new Vector2(rb.velocity.x, jump);
        state = State.jump;
    }

    //Animetion Player
    void AnimationState ()
    {
        if (state == State.jump)
        {
            if (rb.velocity.y < 0.1f)
            {
                state = State.falling;
            }
        }
        else if (state == State.falling)
        {
            if(cooll.IsTouchingLayers(ground))
            {
                state = State.idle;
            }
        }
        else if (state == State.hurt)
        {
            if(Mathf.Abs(rb.velocity.x) < 0.1f)
            {
                state=State.idle;
            }
        }
        else if (Mathf.Abs(rb.velocity.x) > 0.1f)
        {
            state = State.run;
            
        }
        else
        {
            state = State.idle;
        }
    }
}
