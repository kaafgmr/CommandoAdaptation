using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocity = 5f;
    public float shootingRotationSpeed = 5f;
    public Transform ShootingPivot;
    [SerializeField] private AnimationClip throwGranadeAnim;
    public bool movementStopped = false;
    
    private bool throwingGranade = false;
    private Vector2 direction;
    private MovementBehaviour MB;
    private SpriteRenderer SR;
    private ShootingBehaviour SB;
    private AnimationController AC;
    private Vector2 lastDir;
    private Respawn respawn;

    private void Awake()
    {
        respawn = GetComponent<Respawn>();
        SR = GetComponent<SpriteRenderer>();
        SB = GetComponent<ShootingBehaviour>();
        AC = GetComponent<AnimationController>();
        MB = GetComponent<MovementBehaviour>();
        MB.Init(velocity);
        lastDir = Vector2.up;
    }

    private void Start()
    {
        AC.OnAnimationFinished.AddListener(OnAnimFinishedUpdate);
    }

    private void FixedUpdate()
    {
        if(!movementStopped)
        {
            MB.MoveRB(direction);
        }
    }

    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        UpdateShooting();

        if(!movementStopped)
        {
            UpdateMovement(direction);
        }
    }

    private void UpdateShooting()
    {
        ChangeShootingDir();

        if (Input.GetKey(KeyCode.J))
        {
            SB.ShootBullet("PlayerBullet");
        }

        if (Input.GetKeyDown(KeyCode.K) && !throwingGranade && SB.granadeAmount > 0)
        {
            throwingGranade = true;
            movementStopped = true;
            AC.ChangeAnimSpeed(1f);
            AC.ThrowGranadeAnim(1);
            ThrowGranadeUpdate();
        }
    }

    private void UpdateMovement(Vector2 dir)
    {
        if (dir.x != 0 || dir.y != 0)
        {
            AC.ChangeWalkingAnimation(lastDir);
            lastDir = direction;
            AC.ChangeAnimSpeed(1f);
        }
        else
        {
            AC.ChangeAnimSpeed(0f);
        }

        UpdatePlayerImg(lastDir);
    }

    private void UpdatePlayerImg(Vector2 dir)
    {
         SR.flipX = dir.x < 0;
    }

    private void ChangeShootingDir()
    {
        Vector3 shootingDir = SB.shootingPoint.transform.position - ShootingPivot.position;
        float angle = Mathf.Atan2(lastDir.y, lastDir.x) * Mathf.Rad2Deg - 90;

        if (Vector3.Dot(shootingDir, lastDir) < 0.9f)
        {
            ShootingPivot.rotation = Quaternion.Lerp(ShootingPivot.rotation, Quaternion.Euler(0, 0, angle), Time.deltaTime * shootingRotationSpeed);
        }
        else
        {
            ShootingPivot.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    private void OnAnimFinishedUpdate(string animName)
    {
        movementStopped = false;
        AC.ChangeAnimSpeed(0f);

        if (animName == "ThrowGranade")
        {
            OnThrowGranadeAnimFinished();
        }
        else if (animName == "DrownAnim")
        {
            respawn.RespawnObject();
            AC.ChangeAnimSpeed(1f);
        }
    }

    private void ThrowGranadeUpdate()
    {
        AC.ChangeAnimSpeed(1f);
        AC.CheckAnimFinished(throwGranadeAnim);
    }

    private void OnThrowGranadeAnimFinished()
    {
        throwingGranade = false;
        AC.ThrowGranadeAnim(0);
        SB.ShootGranade();
    }
}