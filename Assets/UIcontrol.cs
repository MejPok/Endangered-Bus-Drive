using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIcontrol : MonoBehaviour
{
    public Health health;
    public TextMeshProUGUI passengers;
    public TextMeshProUGUI durability;
    void Update()
    {
        passengers.text = "Passengers: " + health.Passengers;
        durability.text = "Durability: " + health.Durability;
    }
}
