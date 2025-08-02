using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIcontrol : MonoBehaviour
{
    public Health health;
    public TextMeshProUGUI passengers;
    void Update()
    {
        passengers.text = "" + health.Passengers;
    }
}
