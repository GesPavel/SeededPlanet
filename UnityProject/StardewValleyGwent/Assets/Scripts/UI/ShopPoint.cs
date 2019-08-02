using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPoint : MonoBehaviour
{
    public AssortmentWindow assortmentWindow;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandController handController = collision.gameObject.GetComponentInChildren<HandController>();
        if (handController != null)
        {
            assortmentWindow.gameObject.SetActive(true);
            assortmentWindow.ShowAssortment();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        HandController handController = collision.gameObject.GetComponentInChildren<HandController>();
        if (handController != null)
        {
            assortmentWindow.gameObject.SetActive(false);
        }
    }
}
