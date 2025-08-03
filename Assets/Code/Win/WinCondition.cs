using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        
    }
}
