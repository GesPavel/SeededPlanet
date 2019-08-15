using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaDirector : MonoBehaviour
{
    public float maxStamina = 100;
    const float SLOW_DEBUFF = 2;
    const float TIREDNESS_LIMIT = 50;
    public float CurrentStamina { get; private set; }
    public float StaminaLoss { get; private set; } = 1;
    PlayerController player;
    [System.Serializable]
    public enum CalmingAnimals
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
        float staminaLossReduceСoefficient = 0;
        foreach (int typeOfAnimalNearCount in NearestCalmingAnimalsCount.Values)
        {
            staminaLossReduceСoefficient += typeOfAnimalNearCount;
        }
        CurrentStamina -= Time.deltaTime * (StaminaLoss - staminaLossReduceСoefficient);
        if (CurrentStamina > maxStamina)
        {
            CurrentStamina = maxStamina;
        }
        if (CurrentStamina <= 0)
        {
            CurrentStamina = 0;
            SlowDownPlayer();
        }
       else
        {
            player.ResetSpeed();
        }
    }

    private void SlowDownPlayer()
    {
        player.speed = SLOW_DEBUFF;
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
        NearestCalmingAnimalsCount[animal] += 1;
    }
    public void DeleteNearestCalmingAnimal(CalmingAnimals animal)
    {
        NearestCalmingAnimalsCount[animal] -= 1;
    }
    public bool WantToSleep()
    {
        return CurrentStamina < TIREDNESS_LIMIT;
    }
    public bool IsWornOut()
    {
        return CurrentStamina <= 0;
    }
}
