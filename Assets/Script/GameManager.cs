using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject PauseUi;
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        //Plause Game
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale == 1)
            {
                Time.timeScale = 0;
                PauseUi.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                PauseUi.SetActive(false);
            }

        }
    }
  
}
