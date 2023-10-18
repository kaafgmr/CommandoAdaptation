using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ObjectCounter : MonoBehaviour
{
    public float Amount;
    public UnityEvent<float> SendAmount;
    public void SetAmount(float value)
    {
        Amount = value;
    }

    public void UpdateAmount()
    {
        SendAmount.Invoke(Amount);
    }

    public float getAmount()
    {
        return Amount;
    }

    public void IncreaseAmount(float value)
    {
        Amount += value;
        UpdateAmount();
    }

    public void DecreaseAmount(float value)
    {
        Amount -= value;
        UpdateAmount();
    }
}
