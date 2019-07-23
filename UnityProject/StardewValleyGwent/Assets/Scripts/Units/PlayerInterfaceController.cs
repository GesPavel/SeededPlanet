using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInterfaceController : MonoBehaviour
{
    StaminaDirector staminaDirector;
    public Text playerCurrentStaminaText;
    public Text playerCurrentMoneyAmountText;
    void Start()
    {
        staminaDirector = FindObjectOfType<StaminaDirector>();
    }


    
    void Update()
    {
        playerCurrentStaminaText.text = ((int)staminaDirector.CurrentStamina).ToString();
        playerCurrentMoneyAmountText.text = MoneyController.CurrentSum.ToString();
    }
}
