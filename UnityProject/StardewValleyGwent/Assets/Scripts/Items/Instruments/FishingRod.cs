using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingRod : MonoBehaviour, Instrument, IItem
{
    PlayerController player;
    Ground standingGround;
    [SerializeField]
    private string objectsName;
    public string ObjectsName => objectsName;
    [SerializeField] private LayerMask lakeLayer;
    public GameObject fish;
    public float timeToFishing;
    void Start()
    {

    }


    void Update()
    {
        RaycastHit2D lakeHit = Physics2D.Raycast(transform.position, transform.up, 1, lakeLayer);
        if (lakeHit.collider != null && timeToFishing <= 0)
        {
            timeToFishing += Time.deltaTime;
        }
    }

    public void Use(Ground ground)
    {

        RaycastHit2D lakeHit = Physics2D.Raycast(transform.position, transform.up, 1, lakeLayer);
        if (lakeHit.collider != null && timeToFishing>0)
        {
            GameObject newFish = Instantiate(fish, transform.position, Quaternion.identity);
            timeToFishing = -10;
        }
    }

}


