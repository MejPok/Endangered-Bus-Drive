using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PeopleManager : MonoBehaviour
{
    public int People;
    public int PeopleToBoard;
    int peopleGotOn;

    public float Delay;
    public float timer;

    public float leaveTimer;

    public int peopleToLeave;
    bool gotHistory;
    Health busHealth;

    void Start()
    {
        
    }
    public void GetPeople(GameObject bus)
    {
        busHealth = bus.GetComponent<Health>();
        PeopleEagerness();

        PeopleGettingOn();
        PeoplGettingOff();
    }

    bool decided;
    void PeopleEagerness()
    {
        if (decided) return;

        if (busHealth.Durability == 100)
        {
            PeopleToBoard = People;
            peopleToLeave = (int)(busHealth.Passengers * Random.Range(0f, 0.1f));

        }
        else if (busHealth.Durability >= 70)
        {
            PeopleToBoard = (int)(People * Random.Range(0.8f, 1f));
            peopleToLeave = (int)(busHealth.Passengers * Random.Range(0f, 0.3f));

        } 
        else if (busHealth.Durability >= 50)
        {
            PeopleToBoard = (int)(People * Random.Range(0.6f, 0.8f));
            peopleToLeave = (int)(busHealth.Passengers * Random.Range(0.2f, 0.4f));
        }
        else if (busHealth.Durability >= 20)
        {
            PeopleToBoard = (int)(People * Random.Range(0.3f, 0.5f));
            peopleToLeave = (int)(busHealth.Passengers * Random.Range(0.4f, 0.5f));
        }
        else
        {
            PeopleToBoard = (int)(People * Random.Range(0.2f, 0.5f));
            peopleToLeave = (int)(busHealth.Passengers * Random.Range(0.5f, 0.6f));
        }

        if (peopleToLeave > PeopleToBoard)
        {
            peopleToLeave = PeopleToBoard;
        }





        decided = true;

    }

    void PeopleGettingOn()
    {
        timer += Time.deltaTime;

        if (timer > Delay && PeopleToBoard > 0)
        {
            PeopleToBoard--;
            busHealth.Passengers++;
            peopleGotOn++;

            Debug.Log("Person got on the bus");
            timer = 0f;
        }

    }
    void PeoplGettingOff()
    {
        leaveTimer += Time.deltaTime;
        
        

        if (leaveTimer > (Delay * 0.5f) && peopleToLeave > 0)
        {
            if (busHealth.Passengers > 1)
            {
                peopleToLeave--;
                busHealth.Passengers--;
                Debug.Log("Person got off the bus");
                leaveTimer = 0f;
            }
        }
    }
}
