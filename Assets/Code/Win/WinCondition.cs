using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinCondition : MonoBehaviour
{
    public static WinCondition instance { get; set; }

    public bool reachedE;
    public bool reachedA;
    public bool barrierWent;
    public bool Win;

    void Update()
    {
        if (reachedA && reachedE && barrierWent)
        {
            Win = true;
            PlayerPrefs.SetInt("Restricted", 0);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }

    public void reachEStation()
    {
        reachedE = true;
    }
    public void reachAStation()
    {
        if (reachedE)
        {
            reachedA = true;
        }
    }

    public void WentThroughBarrier()
    {
        barrierWent = true;
    }
}
