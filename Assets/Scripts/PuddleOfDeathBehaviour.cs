using UnityEngine;

public class PuddleOfDeathBehaviour : MonoBehaviour
{
    [SerializeField] private AnimationClip drownAnimClip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out AnimationController AC) && collision.TryGetComponent(out HealthBehaviour HB))
        {
            HB.GetHurt(1);
            AC.DrowningAnimation(1);

            if (collision.TryGetComponent(out PlayerController PC))
            {
                PC.movementStopped = true;
                AC.ChangeAnimSpeed(1);
                AC.CheckAnimFinished(drownAnimClip);
            }
        }
    }
}
