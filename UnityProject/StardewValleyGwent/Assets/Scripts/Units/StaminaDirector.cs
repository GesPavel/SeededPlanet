using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaDirector : MonoBehaviour
{
    [SerializeField] private float maxStamina = 100; 
    public float CurrentStamina { get; private set; }
    public float StaminaLoss { get; private set; } = 1;
    PlayerController player;
    public enum CalmingAnimals
    {
        Cat
    }
    public Dictionary<CalmingAnimals, bool> NearestCalmingAnimals { get; private set; }

    private void Awake()
    {
        player = GetComponent<PlayerController>();
        RestoreStamina();
        NearestCalmingAnimals = new Dictionary<CalmingAnimals, bool>();
        NearestCalmingAnimals.Add(CalmingAnimals.Cat, false);
    }
    private void Update()
    {
        float staminaLosssReduceСoefficient = 0;
        foreach(bool isAnimelNear in NearestCalmingAnimals.Values)
        {
            staminaLosssReduceСoefficient += isAnimelNear ? 1 : 0;
        }
        CurrentStamina -= Time.deltaTime * (StaminaLoss-staminaLosssReduceСoefficient);
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
        NearestCalmingAnimals[animal] = true;
    }
    public void DeleteNearestCalmingAnimal(CalmingAnimals animal)
    {
        NearestCalmingAnimals[animal] = false;
    }
}
