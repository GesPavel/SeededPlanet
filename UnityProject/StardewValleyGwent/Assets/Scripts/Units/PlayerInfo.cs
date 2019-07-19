using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    StaminaDirector staminaDirector;
    public Text playersStamina;
    public GameObject catBonus;
    void Start()
    {
        staminaDirector = FindObjectOfType<StaminaDirector>();
    }

    
    void Update()
    {
        playersStamina.text = ((int)staminaDirector.CurrentStamina).ToString();
        if (staminaDirector.StaminaLoss == 0) catBonus.SetActive(true);
        else catBonus.SetActive(false);
    }
}
