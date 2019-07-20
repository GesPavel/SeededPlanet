using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    StaminaDirector staminaDirector;
    public Text playersStaminaText;
    void Start()
    {
        staminaDirector = FindObjectOfType<StaminaDirector>();
    }


    
    void Update()
    {
        playersStaminaText.text = ((int)staminaDirector.CurrentStamina).ToString();
    }
}
