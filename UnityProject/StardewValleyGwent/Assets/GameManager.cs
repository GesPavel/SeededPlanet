using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject lightHous;
    void Awake()
    {
        if (FindObjectOfType<PlayerController>() == null)
            Instantiate(player, lightHous.transform.position, Quaternion.identity);
        else
        {
            Destroy(FindObjectOfType<PlayerController>().gameObject);
            player = Instantiate(player, lightHous.transform.position, Quaternion.identity);

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
