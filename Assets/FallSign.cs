using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
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
    Transform position;
    GameObject whatMove;
    public float speed;
    void Update()
    {
        if (position != null)
        {
            if (whatMove == null)
            {
                transform.Translate((position.position - transform.position) * speed * Time.deltaTime, Space.World);
            }
            else
            {
                transform.Translate((whatMove.transform.position - transform.position) * speed * Time.deltaTime, Space.World);
                
            }
        }
    }
    public void MoveTo(Transform newPos)
    {
        position = newPos;
    }
    public void MoveWhere(Transform newPos, GameObject whatToMove)
    {
        position = newPos;
        whatMove = whatToMove;
    }
    
}
