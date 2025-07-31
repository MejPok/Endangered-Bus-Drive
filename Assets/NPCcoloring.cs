using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCcoloring : MonoBehaviour
{
    void Start()
    {
        var sr = GetComponent<SpriteRenderer>();

        // Clone material to avoid affecting others
        sr.material = new Material(sr.material);
        sr.material.SetColor("_TintColor", Random.ColorHSV());
    }
}
