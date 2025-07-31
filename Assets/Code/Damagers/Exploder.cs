using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bus"))
        {
            Explode(other.gameObject);
        }
    }

    void Explode(GameObject bus)
    {
        Debug.Log("Exploded");
        Health busHealth = bus.GetComponent<Health>();
        busHealth.HitDamager(10);
    }
}
