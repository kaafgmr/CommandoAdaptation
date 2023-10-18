using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform ShootingPivot;
    public float shootingRotationSpeed;
    public float Velocity;
    private Transform Player;
    private Vector3 Direction;
    private SpriteRenderer SR;
    private AnimationController AC;
    private MovementBehaviour MB;
    private ShootingBehaviour SB;

    private void Awake()
    {
        SR = GetComponent<SpriteRenderer>();
        AC = GetComponent<AnimationController>();
        MB = GetComponent<MovementBehaviour>();
        SB = GetComponent<ShootingBehaviour>();
        Player = GameObject.Find("Player").transform;
    }

    private void FixedUpdate()
    {
        MB.MoveRB(Velocity, Direction);
    }
    private void Update()
    {
        SB.ShootBullet("EnemyBullet");

        Direction = (Player.position - transform.position).normalized;

        AC.ChangeWalkingAnimation(Direction);

        float hor = Direction.x;
        float ver = Direction.y;

        //Movement

        if (hor >= 0.5f && hor <= 1 && ver >= 0.5f && ver <= 1f) //up-right
        {
            SR.flipX = false;
            ShootingPivot.rotation = Quaternion.Lerp(ShootingPivot.rotation, Quaternion.Euler(0, 0, 135), Time.deltaTime * shootingRotationSpeed);
        }
        else if (hor >= 0.5f && hor <= 1 && ver <= -0.5f && ver >= -1) //down-Right
        {
            SR.flipX = false;
            ShootingPivot.rotation = Quaternion.Lerp(ShootingPivot.rotation, Quaternion.Euler(0, 0, 45), Time.deltaTime * shootingRotationSpeed);
        }
        else if (hor <= -0.5f && hor >= -1 && ver >= 0.5f && ver <= 1) //up-left
        {
            SR.flipX = true;
            ShootingPivot.rotation = Quaternion.Lerp(ShootingPivot.rotation, Quaternion.Euler(0, 0, -135), Time.deltaTime * shootingRotationSpeed);
        }
        else if (hor <= -0.5f && hor >= -1 && ver <= -0.5f && ver >= -1) //down-Left
        {
            SR.flipX = true;
            ShootingPivot.rotation = Quaternion.Lerp(ShootingPivot.rotation, Quaternion.Euler(0, 0, -45), Time.deltaTime * shootingRotationSpeed);
        }
        else if (hor >= 0.5f && ver >= -0.5f && ver <= 0.5f) //right
        {
            SR.flipX = false;
            ShootingPivot.rotation = Quaternion.Lerp(ShootingPivot.rotation, Quaternion.Euler(0, 0, 90), Time.deltaTime * shootingRotationSpeed);
        }
        else if (hor <= -0.5f && ver >= -0.5f && ver <= 0.5f) //left
        {
            SR.flipX = true;
            ShootingPivot.rotation = Quaternion.Lerp(ShootingPivot.rotation, Quaternion.Euler(0, 0, -90), Time.deltaTime * shootingRotationSpeed);
        }
        else if (ver >= 0.5f && hor >= -0.5f && hor <= 0.5f) //up
        {
            SR.flipX = false;
            ShootingPivot.rotation = Quaternion.Lerp(ShootingPivot.rotation, Quaternion.Euler(0, 0, 180), Time.deltaTime * shootingRotationSpeed);
        }
        else if (ver <= -0.5f && hor >= -0.5f && hor <= 0.5f) //down
        {
            SR.flipX = false;
            ShootingPivot.rotation = Quaternion.Lerp(ShootingPivot.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * shootingRotationSpeed);
        }
        else //idle
        {
            ShootingPivot.rotation = Quaternion.Lerp(ShootingPivot.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * shootingRotationSpeed);
            SR.flipX = false;
        }
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }
}