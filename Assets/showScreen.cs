using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class showScreen : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int NumberOfTries;
    void Start()
    {
        if (PlayerPrefs.HasKey("Try"))
        {
            NumberOfTries = PlayerPrefs.GetInt("Try");
            PlayerPrefs.SetInt("Try", NumberOfTries + 1);
        }
        else
        {
            PlayerPrefs.SetInt("Try", 1);
            NumberOfTries = 1;
        }
        
        text.text = "Loop Number: ";
    }
    float timer;
    bool gotIt;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.9f)
        {
            timer = 0;
            text.text = "Loop Number: " + NumberOfTries;
            if (gotIt)
            {
                Debug.Log("add tick sound");
                Destroy(this.gameObject);
            }
            gotIt = true;
        }
    }
}
