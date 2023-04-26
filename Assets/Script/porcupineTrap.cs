using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class porcupineTrap : MonoBehaviour
{
    public GameObject trap;
    public GameObject trapTrap;
    public AudioSource poraudi;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            trap.SetActive(true);
            poraudi.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            poraudi.Stop();
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        trap.SetActive(false);
    }
}
