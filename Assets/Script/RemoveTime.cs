using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RemoveTime : MonoBehaviour
{
    public Text TimeText;
    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("RemoveTime"))
        {
            GameObject.FindGameObjectWithTag("RemoveTime").GetComponent<Text>().color = new Color32(7, 7, 7, 7);
        }
    }
}