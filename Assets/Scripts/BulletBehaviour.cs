using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float velocity = 10f;
    [SerializeField] private float damage = 1f;
    [SerializeField] private AnimationClip getHurtAnimClip;

    private MovementBehaviour MB;
    private DestroyDisableObjects Dest;
    private Vector3 Direction;

    private void Awake()
    {
        Dest = GetComponent<DestroyDisableObjects>();
        MB = GetComponent<MovementBehaviour>();
        MB.Init(velocity);  
    }

    private void FixedUpdate()
    {
        MB.MoveRB(Direction);
    }

    private void OnBecameInvisible()
    {
        DestroyBullet();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out HealthBehaviour HB) && collision.TryGetComponent(out AnimationController AC))
        {
            HB.GetHurt(damage);
            AC.GetHurtAnimation(1);
            if(collision.TryGetComponent(out PlayerController PC))
            {
                PC.movementStopped = true;
                AC.ChangeAnimSpeed(1);
                AC.CheckAnimFinished(getHurtAnimClip);
            }
        }
        DestroyBullet();
    }
    public void ExplodeShot()
    {
        GameObject shot = PoolingManager.Instance.GetPooledObject("BulletExplosion");

        shot.transform.SetPositionAndRotation(transform.position, transform.rotation);
        AudioManager.instance.PlaySound("BulletHit");
    }

    private void DestroyBullet()
    {
        ExplodeShot();
        Dest.DisableObject();
    }

    public void GetDirection(Vector3 Dir)
    {
        Direction = Dir;
    }
}