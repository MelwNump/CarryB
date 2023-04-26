using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hurt : MonoBehaviour
{
    public AudioSource hurtSound;
    public Animator playerAni;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "HitBoxEnemy")
        {
            if(gameObject.tag == "Hurt")
            {
                playerAni.Play("hurt");
                hurtSound.Play();

            }
        }
    }
}
