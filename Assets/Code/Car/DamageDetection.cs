using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDetection : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Implement wall damage");
        }
        else if (other.gameObject.CompareTag("Damager"))
        {
            Debug.Log("Implement damager");

        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Implement Obstacle");
            
        }
        

    }
}
