using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuddleOfDeathBehaviour : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<AnimationController>(out AnimationController animation) && collision.TryGetComponent<HealthBehaviour>(out HealthBehaviour health))
        {
            animation.DrowningAnimation(1);
            health.GetHurt(1);
        }
    }
}
