using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestAura : MonoBehaviour
{
    private float previousStaminaLoss;
    [SerializeField]private StaminaDirector.CalmingAnimals animalType; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            StaminaDirector playerStamina = FindObjectOfType<StaminaDirector>();
            playerStamina.SetNearestCalmingAnimal(animalType);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            StaminaDirector playerStamina = FindObjectOfType<StaminaDirector>();
            playerStamina.DeleteNearestCalmingAnimal(animalType);
        }
    }
}
