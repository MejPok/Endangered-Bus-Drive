using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;

public class FallSign : MonoBehaviour
{
    public UnityEvent[] whatHappens;

    public string Tag;
    public bool triggered;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(Tag))
        {
            triggered = true;
            for (int i = 0; i < whatHappens.Length; i++)
            {
                whatHappens[i].Invoke();
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
    Transform position;
    GameObject whatMove;
    public float speed;
    void Update()
    {
        if (position != null)
        {
            
            
            
            transform.position = Vector3.MoveTowards(transform.position, position.position, speed * Time.deltaTime * 80);
            
        }
    }
    public void MoveTo(Transform newPos)
    {
        position = newPos;
    }

    
}
