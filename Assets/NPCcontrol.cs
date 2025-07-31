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
        }
    }
    public GameObject CreateNPC()
    {
        Debug.Log(new Vector2(transform.position.x - Random.Range(-3f, 3f) + 6, transform.position.x - Random.Range(-5f, 5f)));
        var npc = Instantiate(basicPrefab, new Vector2(transform.position.x - Random.Range(-3f, 3f) + 6, transform.position.x - Random.Range(-5f, 5f)), Quaternion.identity);
        npc.GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
        
        return npc;
    }

    public void LetNPCin(int number)
    {
        if (npcs.Count > number)
        {
            npcs[number].GetComponent<EnterLeave>().control = this;
            npcs[number].GetComponent<EnterLeave>().Enter(frontDoor);
            
        }
    }
}
