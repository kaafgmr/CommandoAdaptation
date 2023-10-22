using UnityEngine;
using UnityEngine.Events;

public class HealthBehaviour : MonoBehaviour
{
    private float Health;
    public float MaxHealth;

    public UnityEvent<float> InitMaxHealth;
    public UnityEvent<float> OnHurt;
    public UnityEvent OnDie;

    private void Awake()
    {
        Health = MaxHealth;
        InitMaxHealth.Invoke(Health);
    }

    public void GetHurt(float Damage)
    {
        Health -= Damage;
        OnHurt.Invoke(Health);
        if (Health <= 0)
        {
            OnDie.Invoke();
        }
    }

    public float GetCurrentHealth()
    {
        return Health;
    }
}
