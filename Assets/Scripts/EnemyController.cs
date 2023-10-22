using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private Transform shootingPivot;
    [SerializeField] private float shootingRotationSpeed;
    [SerializeField] private float velocity;

    private Transform player;
    private Vector3 direction;
    private SpriteRenderer SR;
    private AnimationController AC;
    private MovementBehaviour MB;
    private ShootingBehaviour SB;

    private void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
        AC = GetComponent<AnimationController>();
        SB = GetComponent<ShootingBehaviour>();
        MB = GetComponent<MovementBehaviour>();
        MB.Init(velocity);
        player = GameObject.Find("Player").transform;
    }

    private void FixedUpdate()
    {
        MB.MoveRB(direction);
    }
    private void Update()
    {
        direction = (player.position - transform.position).normalized;

        AC.ChangeWalkingAnimation(direction);
        FlipEnemyImg();
        
        ChangeShootingDir();
        SB.ShootBullet("EnemyBullet");
    }

    private void ChangeShootingDir()
    {
        Vector3 shootingDir = SB.shootingPoint.transform.position - shootingPivot.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;

        if (Vector3.Dot(shootingDir, direction) < 0.9f)
        {
            shootingPivot.rotation = Quaternion.Lerp(shootingPivot.rotation, Quaternion.Euler(0, 0, angle), Time.deltaTime * shootingRotationSpeed);
        }
        else
        {
            shootingPivot.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void FlipEnemyImg()
    {
        SR.flipX = direction.x < 0;
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}