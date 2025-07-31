using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLeave : MonoBehaviour
{
    public NPCcontrol control;
    public float speed;
    public Transform front;
    public Transform back;

    public bool entering;
    public bool leaving;
    public void Enter(Transform frontT)
    {
        front = frontT;
        entering = true;
        leaving = false;
    }
    public void Leave()
    {
        leaving = true;
        entering = false;
    }
    void Update()
    {
        if (entering)
        {
            transform.position = Vector3.MoveTowards(transform.position, front.position, speed * Time.deltaTime);
            if ((front.position - transform.position).magnitude < 1)
            {
                control.npcs.Remove(this.gameObject);
                Health.Instance.npcs.Add(this.gameObject);
                
            }
        }
    }
}
