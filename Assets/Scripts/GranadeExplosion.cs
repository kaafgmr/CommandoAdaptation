using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadeExplosion : MonoBehaviour
{
    public float Damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<HealthBehaviour>(out HealthBehaviour Object) && collision.TryGetComponent<EnemyController>(out EnemyController e))
        {
            Object.GetHurt(Damage);
        }
    }
}
