using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonDetory : MonoBehaviour
{
    public GameObject donDetory;
    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(donDetory);
    }
}
