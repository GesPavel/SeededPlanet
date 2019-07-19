using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaDirector : MonoBehaviour
{
    [SerializeField] private float maxStamina = 100; 
    private float currentStamina;
    [SerializeField] private float staminaLoss = 5;
    PlayerController player;


    private void Start()
    {
        player = GetComponent<PlayerController>();
        RestoreStamina();
    }
    private void Update()
    {
        currentStamina -= Time.deltaTime * 5;
        if (currentStamina <= 0)
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
        currentStamina -= staminaLost;
    }

    public void RestoreStamina()
    {
        currentStamina = maxStamina;
        Debug.Log("StaminaRestored");
    }
}
