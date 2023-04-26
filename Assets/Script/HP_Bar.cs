using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HP_Bar : MonoBehaviour
{
    public float maxHp;
    private float currenHp;

    public Image hpBar_Front;
    public Image hpBar_Back;
    public GameObject Player;
    public GameObject[] Text;

    //public float addBlood = 1f;
    //public float second = 1f;

    public string sceneName;

    public int trapDmg;
    public int pigDmg;
    public int wormDmg;
    public int birdDmg;
    public int porcupineDmg;
    public AudioSource tapSound;
    public AudioSource coreSound;
    public string SceneName;

    public static HP_Bar hp_Bar;

    private void Awake()
    {
        hp_Bar = this;
    }
    private void Start()
    {
        currenHp = maxHp;
       
        Player.SetActive(true);
        for (int i = 0; i < 8; i++)
        {
            Text[i].SetActive(true);
        }
    }

    //Hp Bar  
    void SyncBar()
    {
        hpBar_Front.fillAmount = currenHp / maxHp;
        if (hpBar_Back.fillAmount > hpBar_Front.fillAmount)
        {
            hpBar_Back.fillAmount = Mathf.Lerp(hpBar_Back.fillAmount,
                hpBar_Front.fillAmount, Time.deltaTime);
        }
    }

    private void Update()
    {
        SyncBar();
        Dead();
    }

    //Damage Monter and Heal Player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "pigdamage" )
        {
            currenHp -= pigDmg;
        } 
        else if (collision.tag == "Tap")
        {
            currenHp -= trapDmg;
            tapSound.Play();
        }
        else if (collision.tag == "bird")
        {
            currenHp -= birdDmg;
        }
        else if(collision.tag == "worm")
        {
            currenHp -= wormDmg;
           
        }
        else if (collision.tag == "porcupine")
        {
            currenHp -= porcupineDmg;
        }
        else if (collision.tag == "Soul")
        {
            currenHp += 5f;
            coreSound.Play();
            Destroy(collision.gameObject);
            

        }
        else if (collision.tag == "Soul_Worm")
        {
            currenHp += 10f;
            coreSound.Play();
            Destroy(collision.gameObject);
            

        }
        else if (collision.tag == "Soul_Pig")
        {
            currenHp += 30f;
            coreSound.Play();
            Destroy(collision.gameObject);
            

        }
        else if(collision.tag == "BossPig")
        {
            currenHp -= 20f;
        }

    }
    // if hp = 0 Player Dead
    public void Dead()
    {

        if (currenHp <= 0)
        {
            SceneManager.LoadScene(SceneName);
        }
    }

    //Add Hp Player
    public void IncreaseHp(int value)
    {
        if(currenHp >= maxHp)
        {
            maxHp = currenHp;
        }
        else
        {
            currenHp += value;
        }
    }
}
