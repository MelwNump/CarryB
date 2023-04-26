using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wormSound : MonoBehaviour
{
    public AudioSource wormAudi;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            wormAudi.Play();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            wormAudi.Stop();
        }
    }
}
