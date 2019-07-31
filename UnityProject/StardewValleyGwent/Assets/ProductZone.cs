using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductZone : MonoBehaviour
{
    [SerializeField] private GameObject product;
    [SerializeField] private float delayTime = 5f;
    private float timeBeforNextUse;
    public void SpawnProduct()
    {
        if (!IsAbleToSpawn())
        {
            return;
        }
        timeBeforNextUse = delayTime;
        Instantiate(product, transform.position, Quaternion.identity);
    }

    public bool IsAbleToSpawn()
    {
        if (timeBeforNextUse > 0)
        {
            return false;
        }
        return true;
    }

    private void Update()
    {
        if (timeBeforNextUse >= 0)
        {
            timeBeforNextUse -= Time.deltaTime;
        }
    }
}
