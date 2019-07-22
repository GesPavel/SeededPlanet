using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    [SerializeField] private int initialSum;
    public static int CurrentSum { get; private set; }

    private void Start()
    {
        CurrentSum = initialSum;
    }
    public void AddMoney(int sum)
    {
        CurrentSum += sum;
    }

    public void Subtract(int sum)
    {
        CurrentSum -= sum;
    }

    public bool CheckIsEnoughMoney(int sum)
    {
        return CurrentSum >= sum;
    }
}
