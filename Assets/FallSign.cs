using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FallSign : MonoBehaviour
{
    public UnityEvent[] whatHappens;
    public string Tag;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(Tag))
        {
            for (int i = 0; i < whatHappens.Length; i++)
            {
                whatHappens[i].Invoke();
            }
        }
        
    }
}
