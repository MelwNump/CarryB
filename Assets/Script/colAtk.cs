using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class colAtk : MonoBehaviour
{
    public ATK atk;

    public TextMeshProUGUI dmgText;

    //Show Damage
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "HitBoxEnemy")
        {
            dmgText.gameObject.SetActive(true);
        }
    }
}
