using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float velocity = 10f;
    [SerializeField] private float damage = 1f;

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
        if(collision.TryGetComponent<HealthBehaviour>(out HealthBehaviour Object) && collision.TryGetComponent<AnimationController>(out AnimationController AC))
        {
            Object.GetHurt(damage);
            AC.GetHurtAnimation(1);
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