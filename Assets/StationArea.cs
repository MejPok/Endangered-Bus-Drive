using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StationArea : MonoBehaviour
{
    public int whatLevelEnable;
    public string Tag;
    bool triggered;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(Tag))
        {
            triggered = true;
            if (other.gameObject.GetComponent<Health>().Alive)
            {
                RestrictedRoad.restrictedRoad.SetRestrictedLevel(whatLevelEnable);
            }
            
        }


    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(Tag))
        {
            triggered = false;
        }
        

    }
}
