using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int MaxDurability;
    public int Durability;

    public int Passengers;

    void Start()
    {
        Durability = MaxDurability;


    }

    public void HitObstacle(int damage)
    {
        
    }

}
