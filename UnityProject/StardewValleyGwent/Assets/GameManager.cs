using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnPoint;
    void Awake()
    {
        if (FindObjectOfType<PlayerController>() == null)
            Instantiate(player, spawnPoint.transform.position, Quaternion.identity);
        else
        {
            Destroy(FindObjectOfType<PlayerController>().gameObject);
            player = Instantiate(player, spawnPoint.transform.position, Quaternion.identity);

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
