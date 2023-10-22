using UnityEngine;

public class GranadeBehaviour : MonoBehaviour
{
    [SerializeField]private float velocity = 8f;
    [SerializeField]private float timeToExplode = 1f;

    private float _time;
    private Vector3 Direction;
    private MovementBehaviour MB;

    private void Awake()
    {
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
            gameObject.SetActive(false);
            ExplodeGranade();
        }
    }

    public void ExplodeGranade()
    {
        GameObject explosion = PoolingManager.Instance.GetPooledObject("GranadeExplosion");

        explosion.transform.SetPositionAndRotation(transform.position, transform.rotation);
        explosion.GetComponent<ExplosionBehaviour>().CheckExploded();
        AudioManager.instance.PlaySound("GranadeExplosion");
    }

    public void SetDirection(Vector3 Dir)
    {
        Direction = Dir;
    }
}