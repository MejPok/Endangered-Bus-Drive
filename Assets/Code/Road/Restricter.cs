using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restricter : MonoBehaviour
{
    public int MyAreaLevel;

    void Start()
    {
        if (MyAreaLevel <= RestrictedRoad.restrictedRoad.level)
        {
            gameObject.SetActive(false);
        }
    }
}
