using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    private float Velocity;
    private Vector3 Direction;

    public void Init(float Vel, Vector3 Dir)
    {
        Velocity = Vel;
        Direction = Dir;
    }

    public void Init(float Vel)
    {
        Velocity = Vel;
    }
    public void Move()
    {
        transform.position = transform.position + Velocity * Direction * Time.deltaTime; 
    }

    public void Move(Vector3 dir)
    {
        transform.position = transform.position + Velocity * dir * Time.deltaTime;
    }

    public void Move(float Vel)
    {
        transform.position = transform.position + Vel * Direction * Time.deltaTime;
    }

    public void Move(float Vel, Vector3 Dir)
    {
        transform.position = transform.position + Vel * Dir * Time.deltaTime;
    }

    public void MoveRB()
    {
        GetComponent<Rigidbody2D>().MovePosition(transform.position + Velocity * Direction * Time.fixedDeltaTime);
    }
    public void MoveRB(float Vel)
    {
        GetComponent<Rigidbody2D>().MovePosition(transform.position + Vel * Direction * Time.fixedDeltaTime);
    }
    public void MoveRB(Vector3 dir)
    {
        GetComponent<Rigidbody2D>().MovePosition(transform.position + Velocity * dir * Time.fixedDeltaTime);
    }

    public void MoveRB(float Vel, Vector3 dir)
    {
        GetComponent<Rigidbody2D>().MovePosition(transform.position + Vel * dir * Time.fixedDeltaTime);
    }

    public void ChangeVelocity(float amount)
    {
        Velocity = amount;
    }

    public void ChangeDirection(Vector3 newDir)
    {
        Direction = newDir;
    }

    public float getVelocity()
    {
        return Velocity;
    }

    public Vector3 getDirection()
    {
        return Direction;
    }
}