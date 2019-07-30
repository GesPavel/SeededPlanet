using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Vegetable, IBuffable
{
    public GameObject catsHallucination;
    GameObject newHallucination;
    GameObject player;
    public void Buff()
    {
        player = FindObjectOfType<PlayerController>().gameObject;
        newHallucination = Instantiate(catsHallucination, transform.position, Quaternion.identity);
        newHallucination.transform.SetParent(player.transform);
        Destroy(newHallucination,10);
    }
}
