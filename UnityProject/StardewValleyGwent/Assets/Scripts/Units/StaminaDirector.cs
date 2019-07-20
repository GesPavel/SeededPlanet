using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaDirector : MonoBehaviour
{
    [SerializeField] private float maxStamina = 100; 
    public float CurrentStamina { get; private set; }
    public float StaminaLoss { get; private set; } = 1;
    PlayerController player;
    [System.Serializable]public enum CalmingAnimals
    {
        Cat
    }
    public static Dictionary<CalmingAnimals, int> NearestCalmingAnimalsCount { get; private set; }
    private void Awake()
    {
        player = GetComponent<PlayerController>();
        RestoreStamina();
        NearestCalmingAnimalsCount = new Dictionary<CalmingAnimals, int>();
        NearestCalmingAnimalsCount.Add(CalmingAnimals.Cat, 0);
    }
    private void Update()
    {
        float staminaLosssReduceСoefficient = 0;
        foreach(int typeOfAnimelNearCount in NearestCalmingAnimalsCount.Values)
        {
            staminaLosssReduceСoefficient += typeOfAnimelNearCount;
        }
        CurrentStamina -= Time.deltaTime * (StaminaLoss-staminaLosssReduceСoefficient);
        if (CurrentStamina > maxStamina) CurrentStamina = maxStamina;
        if (CurrentStamina <= 0)
        {
            Faint();
        }
    }
    private void Faint()
    {
        gameObject.transform.position = FindObjectOfType<Bed>().gameObject.transform.position;
        RestoreStamina();
    }

    public void DecreaseStamina(float staminaLost)
    {
        CurrentStamina -= staminaLost;
    }

    public void IncreaseStamina(float staminaGain)
    {
        CurrentStamina += staminaGain;
        if (CurrentStamina > maxStamina)
            CurrentStamina = maxStamina;
    }

    public void RestoreStamina()
    {
        CurrentStamina = maxStamina;
    }
    
    public void SetNearestCalmingAnimal(CalmingAnimals animal)
    {
        NearestCalmingAnimalsCount[animal]+=1;
    }
    public void DeleteNearestCalmingAnimal(CalmingAnimals animal)
    {
        NearestCalmingAnimalsCount[animal] -=1;
    }
}
