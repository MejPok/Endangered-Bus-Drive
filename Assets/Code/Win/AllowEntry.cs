using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowEntry : MonoBehaviour
{
    void Update()
    {
        if (Health.Instance.gameObject.transform.position.y < gameObject.transform.position.y)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = true;
            
        }
    }
}
