using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBoss : MonoBehaviour
{
    public float hp;
    public float hp_Cur;

    public Image hpBar_Front;
    public Image hpBar_Back;
    public GameObject Enemy;
    public GameObject[] Text;

    public GameObject door;
    [SerializeField] private GameObject expo;

    private void Start()
    {
        door.SetActive(false);
        hp_Cur = hp;
        Enemy.SetActive(true);
        for (int i = 0; i < 4; i++)
        {
            Text[i].SetActive(true);
        }
    }

    void SyncBar()
    {
        hpBar_Front.fillAmount = hp_Cur / hp;
        if (hpBar_Back.fillAmount > hpBar_Front.fillAmount)
        {
            hpBar_Back.fillAmount = Mathf.Lerp(hpBar_Back.fillAmount,
                hpBar_Front.fillAmount, Time.deltaTime);
        }
    }

    private void Update()
    {
        SyncBar();
        dedgo();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DmgPlayer")
        {
            hp_Cur -= Random.Range(100, 500);
        }
    }

    public void dedgo()
    {

        if (hp_Cur <= 0)
        {
            door.SetActive(true);

            Instantiate(expo, transform.position, Quaternion.identity);
            var cory = Instantiate(expo);
            Destroy(cory, 1.5f);
            Destroy(Enemy);

            for (int i = 0; i < 4; i++)
            {
                Text[i].SetActive(false);
            }
        }
    }
}

