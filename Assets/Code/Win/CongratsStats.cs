using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CongratsStats : MonoBehaviour
{
    public int loops;
    public TextMeshProUGUI loopsText;
    void Start()
    {
        loops = PlayerPrefs.GetInt("Try");
        PlayerPrefs.SetInt("Try", 0);

        loopsText.text = "Loops: " + loops;
    }
}
