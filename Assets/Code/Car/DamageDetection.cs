using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageDetection : MonoBehaviour
{
    Rigidbody2D rb;
    void OnCollisionEnter2D(Collision2D other)
    {
        rb = GetComponent<Rigidbody2D>();
        if (other.gameObject.CompareTag("Wall"))
        {
            if (rb.velocity.magnitude > 1)
            {
                GetComponent<Health>().HitWall((int)rb.velocity.magnitude);
            }
        }
        else if (other.gameObject.CompareTag("Damager"))
        {
            

        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Implement Obstacle");

        }
        

    }
}
