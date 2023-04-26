using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class cutScene : MonoBehaviour
{
    public string sceneName;
    public float changeTime;

    private void Update()
    {
        changeTime -= Time.deltaTime;
        if(changeTime <=0)
        {
            SceneManager.LoadScene(sceneName);
        }
        
    }
}
