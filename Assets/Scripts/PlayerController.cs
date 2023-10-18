using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocity = 5f;
    public float shootingRotationSpeed = 5f;
    public Transform ShootingPivot;
    
    private bool throwingGranade = false;
    private Vector2 direction;
    private MovementBehaviour MB;
    private SpriteRenderer SR;
    private ShootingBehaviour SB;
    private AnimationController AC;
    private Vector2 lastDir;

    private void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
        SB = GetComponent<ShootingBehaviour>();
        AC = GetComponent<AnimationController>();
        MB = GetComponent<MovementBehaviour>();
        MB.Init(velocity);
    }

    private void FixedUpdate()
    {
        MB.MoveRB(direction);
    }

    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        UpdateShooting();

        UpdateMovement(direction);
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
        }
        else
        {
            AC.ChangeAnimSpeed(0f);
        }

        UpdateFlipPlayerImg(lastDir);
    }

    private void UpdateFlipPlayerImg(Vector2 dir)
    {
        if (dir.x < 0)
        {
            SR.flipX = true;
        }
        else
        {
            SR.flipX = false;
        }
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

    private void ThrowGranadeUpdate()
    {
        StartCoroutine(CheckAnimFinished());
    }

    IEnumerator CheckAnimFinished()
    {
        while (AC._anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
        {
            yield return null;
        }

        OnThrowGranadeAnimFinished();
    }

    private void OnThrowGranadeAnimFinished()
    {
        throwingGranade = false;
        AC.ThrowGranadeAnim(0);
        SB.ShootGranade();
    }
}