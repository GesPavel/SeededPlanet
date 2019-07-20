using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusElementIcon : MonoBehaviour
{
    [SerializeField]StaminaDirector.CalmingAnimals typeOfAnimal;
    public Text currentAnimalOfThisTypeText;

    private void Start()
    {
    }
    void Update()
    {
        currentAnimalOfThisTypeText.text = StaminaDirector.NearestCalmingAnimalsCount[typeOfAnimal].ToString();
    }
}
