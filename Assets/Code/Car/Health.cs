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
        Debug.Log("" + Durability);
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
}
