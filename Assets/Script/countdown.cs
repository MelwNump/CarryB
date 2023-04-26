using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class countdown : MonoBehaviour
{
    public Text scoreTime;
    public Text timetext;
    public float scoreAmount;
    public float pointIncreasedPerSecond;
    public float timeLimit = 11f;
    public float timeremain;
    public int minutes;
    public int secondsFill;
    public int addTime;
    public int time;
    public string sceneName;
    public AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        timeremain = 11f;
        scoreAmount = 60f;
        pointIncreasedPerSecond = 1f;
        secondsFill = 0;
        //DontDestroyOnLoad(donDetoryObj);

    }

    // Update is called once per frame
    void Update()
    {
        CountdownTime();
        OutOfTime();
        timescore();
    }

    //Time Countdown 
    public void CountdownTime()
    {
        //scoreTime.text = "Time: " + (int)minutes + ":" + (int)secondsFill + (int)scoreAmount;
        scoreAmount -= pointIncreasedPerSecond * Time.deltaTime;
        timetext.text = " " + timeremain + ":" + (int)scoreAmount;
        

        if (scoreAmount < 0)
        {
            minutes++;
            timeremain = timeLimit - minutes;
            scoreAmount = 60f;
           
        }
    }

    // Out Of Time Chang Scene
    public void OutOfTime()
    {
        if (timeremain <= -1)
        {
            SceneManager.LoadScene(sceneName);
        }
    }

   // Add Time if pic up item
   private void OnTriggerEnter2D(Collider2D collision)
   {
        if (collision.tag == "Time")
        {
            timeremain += addTime;
            minutes -= addTime;
            audioSource.Play();

            Destroy(collision.gameObject);
        }
    }

    // End game send time value have score 
    public void timescore()
    {
        PlayerPrefs.SetFloat("ScoreTime",timeremain);
    }
}
