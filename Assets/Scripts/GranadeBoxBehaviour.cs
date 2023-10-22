using UnityEngine;

public class GranadeBoxBehaviour : MonoBehaviour
{
    public int granadeAmountToGive = 1;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out ShootingBehaviour SB))
        {
            int newAmount = SB.granadeAmount += granadeAmountToGive;
            SB.UpdateGranadeAmount(newAmount);
        }

        Destroy(gameObject);
        AudioManager.instance.PlaySound("PickUp");
    }
}