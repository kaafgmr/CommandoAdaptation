using UnityEngine;

public class GranadeExplosion : MonoBehaviour
{
    [SerializeField] private float damage = 100;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out HealthBehaviour HB) && collision.TryGetComponent(out EnemyController _))
        {
            HB.GetHurt(damage);
        }
    }
}
