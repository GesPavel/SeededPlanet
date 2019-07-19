using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaDirector : MonoBehaviour
{
    [SerializeField] private float maxStamina = 100; 
    public float CurrentStamina { get; private set; }
    public float StaminaLoss { get; private set; } = 1;
    PlayerController player;


    private void Start()
    {
        player = GetComponent<PlayerController>();
        RestoreStamina();
    }
    private void Update()
    {
        CurrentStamina -= Time.deltaTime * StaminaLoss;
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
    public void SetStaminaLoss(float newStaminaLoss)
    {
        StaminaLoss = newStaminaLoss;
    }
    public float GetStaminaLoss()
    {
        return StaminaLoss;
    }
}
