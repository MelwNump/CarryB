using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removetrapp : MonoBehaviour
{
    public GameObject[] pp;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "porcupine")
        {
            for (int i = 0; i < 20; i++)
            {
                Destroy(pp[i]);
            }
        }
    }
}
