using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Busdetection : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bus")
        {
            Debug.Log("Bus triggered");
            GameObject bus = collision.gameObject;
            var doors = bus.GetComponent<OpenDoor>();
            if (doors.DoorOpened)
            {
                GetComponent<PeopleManager>().GetPeople(bus);
                
            }
        }
    }
}
