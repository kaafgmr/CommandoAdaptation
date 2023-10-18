using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadeBoxBehaviour : MonoBehaviour
{
    public int GranadeAmountToGive; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int NewAmount = collision.GetComponent<ShootingBehaviour>().granadeAmount += GranadeAmountToGive;
        collision.GetComponent<ShootingBehaviour>().UpdateGranadeAmount(NewAmount);
        GetComponent<DestroyDisableObjects>().DestroyObject();
        AudioManager.instance.PlaySound("PickUp");
    }
}
