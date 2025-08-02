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

    public int Passengers {get{ return npcs.Count; } set{}}

    public List<GameObject> npcs = new List<GameObject>();

    public Transform BackDoor;
    public bool Alive;

    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        Durability = MaxDurability;
        Alive = true;
    }

    public void HitObstacle(int damage)
    {
        Durability -= damage;

    }
    public void HitWall(int damage)
    {
        Durability -= damage;
        Debug.Log("wall for " + damage);

        if (damage > 60) { Passengers -= 7; }
        else if (damage > 40) { Passengers -= 4; }
        else if (damage > 30) { Passengers -= 2; }
        else if (damage > 20) { Passengers -= 1; }
        else if (damage > 10) { if (Random.Range(0, 10) == 1) Passengers -= 1; }
        else if (damage > 5) { if (Random.Range(0, 15) == 1) Passengers -= 1; }

        DeathCheck();
    }
    public void HitDamager(int damage)
    {
        Durability -= damage;
        NpcDeath((int)(damage / 10));
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
        Alive = false;
        GetComponent<Death>().Dead();
        Debug.Log("Player died");
    }

    public ParticleSystem bloodEffect;
    public void NpcDeath(int deaths)
    {
        for (int i = 0; i < deaths; i++)
        {
            if (npcs.Count > 0)
            {
                var npc = npcs[0];
                npcs.RemoveAt(0);
                Destroy(npc);
                SoundManager.Instance.PlaySoundFX(GetComponent<FXChoser>().audioClips[Random.Range(0, GetComponent<FXChoser>().audioClips.Length)], transform, 100);
                DeathCheck();
                Instantiate(bloodEffect, transform.position, Quaternion.identity).
                GetComponent<ParticleSystem>().Play();

            }
        }

    }
}
