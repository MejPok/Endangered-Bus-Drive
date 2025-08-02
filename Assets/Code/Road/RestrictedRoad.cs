using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestrictedRoad : MonoBehaviour
{
    public static RestrictedRoad restrictedRoad { get; set; }
    public string Key;
    public int level;
    void Awake()
    {
        restrictedRoad = this;
        
        if (PlayerPrefs.HasKey(Key))
        {
            level = PlayerPrefs.GetInt(Key);
        }
        else
        {
            level = 0;
        }

        
    }

    public void SetRestrictedLevel(int area)
    {
        PlayerPrefs.SetInt(Key, area);
    }
}
