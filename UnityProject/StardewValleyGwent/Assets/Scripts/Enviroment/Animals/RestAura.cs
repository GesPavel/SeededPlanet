using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestAura : MonoBehaviour
{
    private float previousStaminaLoss;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            StaminaDirector playerStamina = FindObjectOfType<StaminaDirector>();
            playerStamina.SetNearestCalmingAnimal(StaminaDirector.CalmingAnimals.Cat);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            StaminaDirector playerStamina = FindObjectOfType<StaminaDirector>();
            playerStamina.DeleteNearestCalmingAnimal(StaminaDirector.CalmingAnimals.Cat);
        }
    }
}
