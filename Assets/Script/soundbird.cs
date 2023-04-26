using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundbird : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource bridAudi;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            bridAudi.Play();
        }
            
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            bridAudi.Stop();
        }
            
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
