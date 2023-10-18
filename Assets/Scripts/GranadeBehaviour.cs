using UnityEngine;

public class GranadeBehaviour : MonoBehaviour
{
    [SerializeField]private float velocity = 8f;
    [SerializeField]private float timeToExplode = 1f;

    private float _time;
    private Vector3 Direction;
    private MovementBehaviour MB;
    private DestroyDisableObjects DD;

    private void Awake()
    {
        DD = GetComponent<DestroyDisableObjects>();
        MB = GetComponent<MovementBehaviour>();
        MB.Init(velocity);
        _time = timeToExplode;
    }

    private void Update()
    {
        _time -= Time.deltaTime;
        if(_time >= 0)
        {
            MB.Move(Direction);
        }
        else
        {
            _time = timeToExplode;
            DD.DisableObject();
            ExplodeGranade();
        }
    }

    public void ExplodeGranade()
    {
        GameObject shot = PoolingManager.Instance.GetPooledObject("GranadeExplosion");

        shot.transform.SetPositionAndRotation(transform.position, transform.rotation);
        AudioManager.instance.PlaySound("GranadeExplosion");
    }

    public void SetDirection(Vector3 Dir)
    {
        Direction = Dir;
    }
}