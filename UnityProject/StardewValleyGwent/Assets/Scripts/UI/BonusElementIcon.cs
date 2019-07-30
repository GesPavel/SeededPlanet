using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusElementIcon : MonoBehaviour
{
    [SerializeField]StaminaDirector.CalmingAnimals typeOfAnimalToShow;
    public Text currentAnimalAmountText;

    private void Start()
    {
    }
    void Update()
    {
        currentAnimalAmountText.text = StaminaDirector.NearestCalmingAnimalsCount[typeOfAnimalToShow].ToString();
    }
}
