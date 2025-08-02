using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DurabilSlider : MonoBehaviour
{
    void Update()
    {
        GetComponent<Slider>().value = Health.Instance.Durability;
        GetComponent<Slider>().maxValue = Health.Instance.MaxDurability;

    }
}
