using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public GameObject panel;
    public void Dead()
    {
        panel.SetActive(true);
        count = true;
        

    }
    bool count;
    float timer;
    void Update()
    {
        if(count)
        timer += Time.deltaTime;
        if (timer > 2f)
        {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
        }
    }
}
