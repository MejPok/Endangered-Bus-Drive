using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCcontrol : MonoBehaviour
{
    public GameObject bus;
    public Sprite[] sprites;
    public List<GameObject> npcs = new List<GameObject>();
    public GameObject basicPrefab;
    PeopleManager pm;

    public Transform frontDoor;
    public Transform backDoor;

    void Start()
    {
        pm = GetComponent<PeopleManager>();

        for (int i = 0; i < pm.People; i++)
        {
            npcs.Add(CreateNPC());
            npcs[i].GetComponent<EnterLeave>().control = this;
        }
    }
    public Vector2 SpawnDirection;
    public GameObject CreateNPC()
    {
        Debug.Log(new Vector2(transform.position.x - Random.Range(-3f, 3f) , transform.position.x - Random.Range(-5f, 5f)));
        var npc = Instantiate(basicPrefab, new Vector2(transform.position.x - Random.Range(-3f, 3f) + SpawnDirection.x, SpawnDirection.y + transform.position.y - Random.Range(-5f, 5f)) , Quaternion.identity);
        npc.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];

        return npc;
    }

    public void LetNPCin(int number)
    {
        
        npcs[0].GetComponent<EnterLeave>().control = this;
        if (npcs[0].GetComponent<EnterLeave>().entering)
        {
             Debug.Log("its more times");
        }
        npcs[0].GetComponent<EnterLeave>().Enter(frontDoor);
        npcs.RemoveAt(0);

        
    }
}
