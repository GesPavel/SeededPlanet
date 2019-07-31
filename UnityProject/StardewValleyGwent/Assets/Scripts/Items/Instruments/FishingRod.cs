using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingRod : MonoBehaviour, INonGroundItem, IItem
{
    PlayerController player;
    Ground standingGround;
    [SerializeField]
    private string objectsName;
    public string ObjectsName => objectsName;
    [SerializeField]
    private LayerMask lakeLayer;
    public GameObject[] haul;
    public GameObject fishingFloat;
    GameObject newFishingFloat;
    bool floatIsActive;

    void Start()
    {

    }
    void InstantiateFishingFloat()
    {
        if (!floatIsActive)
        {
            newFishingFloat = Instantiate(fishingFloat, transform.position + transform.up * 3, Quaternion.identity);
            floatIsActive = true;
        }
    }
    void OnDisable()
    {
        Destroy(newFishingFloat);
    }
    void Update()
    {
        RaycastHit2D lakeHit = Physics2D.Raycast(transform.position, transform.up, 1, lakeLayer);
        if (lakeHit.collider != null)
        {
            InstantiateFishingFloat();
        }
        if (lakeHit.collider == null)
        {
            Destroy(newFishingFloat);
            floatIsActive = false;
        }
    }

    public void Use()
    {

        RaycastHit2D lakeHit = Physics2D.Raycast(transform.position, transform.up, 1, lakeLayer);
        if (lakeHit.collider != null)
        {
            if (FishingFloat.youCanGetFish)
            {
                GameObject newFish = Instantiate(haul[Random.Range(0,haul.Length)], transform.position, Quaternion.identity);
            }
            else
            {
                Debug.Log("LOX");
            }
        }
    }
}




