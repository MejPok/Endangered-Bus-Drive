using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public bool DoorOpened;

    public float Delay;
    public float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && timer > Delay)
        {
            DoorOpened = !DoorOpened;
            timer = 0f;
        }
        
    }
}
