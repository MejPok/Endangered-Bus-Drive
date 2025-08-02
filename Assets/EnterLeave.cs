using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnterLeave : MonoBehaviour
{
    public NPCcontrol control;
    public float speed;
    public Transform front;
    public Transform back;

    public bool entering;
    public bool leaving;
    public GameObject sadSmile;
    public void Enter(Transform frontT)
    {
        front = frontT;
        entering = true;
        leaving = false;
        Debug.Log("trying to get on");
    }
    public void Leave()
    {
        leaving = true;
        entering = false;
        Debug.Log("trying to leave");

    }
    void Update()
    {
        if (entering)
        {
            transform.position = Vector3.MoveTowards(transform.position, front.position, speed * Time.deltaTime);
            if ((front.position - transform.position).magnitude < 1)
            {

                Health.Instance.npcs.Add(this.gameObject);
                Health.Instance.Durability += 5;
            }
        }

        if (leaving)
        {
            var position = new Vector2(transform.position.x + 20, transform.position.y);
            transform.position = Vector3.MoveTowards(transform.position, position, speed * Time.deltaTime);
            if ((position - (Vector2)transform.position).magnitude < 1)
            {
                Destroy(this.gameObject);

            }
        }
    }
    bool done = false;
    public void SpawnSadSmile()
    {
        if (done) return;

        GameObject smile = Instantiate(sadSmile, new Vector2(transform.position.x, transform.position.y + 2), Quaternion.identity);
        Destroy(smile, 3);
        Leave();
        done = true;
    }
}
