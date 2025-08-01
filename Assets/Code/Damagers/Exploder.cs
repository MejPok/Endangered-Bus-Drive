using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    public GameObject explosionEffect;
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
        busHealth.HitDamager(90);
        Instantiate(explosionEffect, transform.position, Quaternion.identity).
        GetComponent<ParticleSystem>().Play();

        Vector2 direction = bus.transform.position - transform.position;
        bus.GetComponent<Rigidbody2D>().AddForce(direction * 200);


        SoundManager.Instance.PlaySoundFX(GetComponent<FXChoser>().audioClips[Random.Range(0, GetComponent<FXChoser>().audioClips.Length)], transform, 100);

        Destroy(this.gameObject);
    }
}
