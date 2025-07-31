using System.Collections;
using System.Collections.Generic;
using AOT;
using UnityEngine;
using UnityEngine.UIElements;

public class Health : MonoBehaviour
{
    public static Health Instance { get; private set; }
    public int MaxDurability;
    public int Durability;

    public int Passengers;

    public List<GameObject> npcs = new List<GameObject>();

    public Transform BackDoor;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Durability = MaxDurability;
    }

    public void HitObstacle(int damage)
    {

    }
    public void HitDamager(int damage)
    {
        Durability -= damage;
        Passengers -= damage;
        DeathCheck();
        Debug.Log("" + Durability);
        Debug.Log("Passengers died " + damage);
        Debug.Log("Implement passengers death screens");
    }

    void Update()
    {
        foreach (GameObject npc in npcs)
        {
            npc.SetActive(false);
            npc.transform.position = BackDoor.position;
        }
        Passengers = npcs.Count;
    }

    public void LetNpcLeave()
    {
        if (npcs.Count > 0)
        {
            var npc = npcs[0];
            npcs.RemoveAt(0);
            npc.SetActive(true);
            npc.transform.position = BackDoor.position;
            npc.GetComponent<EnterLeave>().Leave();
        }


    }

    public void DeathCheck()
    {
        if (Passengers <= 0 || Durability <= 0)
        {
            Death();
            
        }

    }

    public void Death()
    {
        
        Debug.Log("Player died");
    }

}
