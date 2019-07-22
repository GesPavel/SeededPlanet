using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyController : MonoBehaviour
{
    [SerializeField]private int initialSum;
    public static int CurrentSum { get; private set; }

    private void Start()
    {
        CurrentSum = initialSum;
    }
    public void AddMoney(int sum)
    {
        if (sum > 0)
        {
            CurrentSum += sum;
        }
    }

    public bool Subtract(int sum)
    {
        if (sum > CurrentSum) return false;
        CurrentSum -= sum;
        return true;
    }
}
