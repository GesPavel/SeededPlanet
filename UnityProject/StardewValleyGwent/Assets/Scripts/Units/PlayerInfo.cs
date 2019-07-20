using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    StaminaDirector staminaDirector;
    public Text playersStaminaText;
    public GameObject StaminaBonus;
    void Start()
    {
        staminaDirector = FindObjectOfType<StaminaDirector>();
    }

    
    void Update()
    {
        playersStaminaText.text = ((int)staminaDirector.CurrentStamina).ToString();
        StaminaBonus.SetActive(false);
        foreach (bool isNearCalmingAnimal in staminaDirector.NearestCalmingAnimals.Values)
        {
            if (isNearCalmingAnimal)
            {
                StaminaBonus.SetActive(true);
                return;
            }
        }
    }
}
