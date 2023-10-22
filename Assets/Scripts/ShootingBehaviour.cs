using UnityEngine;
using UnityEngine.Events;

public class ShootingBehaviour : MonoBehaviour
{
    public Transform shootingPoint;
    public float fireRate;
    public UnityEvent<int> UpdateGranadeValue;
    public UnityEvent<int> SetGranadeValue;
    public int granadeAmount;
    
    private float _time;

    private void Awake()
    {
        SetGranadeValue.Invoke(granadeAmount);
    }

    public void ShootBullet(string ShotingType)
    {
        _time += Time.deltaTime;

        if (_time < fireRate) return;
        _time = 0;

        GameObject shot = PoolingManager.Instance.GetPooledObject(ShotingType);

        shot.transform.SetPositionAndRotation(shootingPoint.position, shootingPoint.rotation);
        Vector3 BulletDir = shootingPoint.position - transform.position;
        shot.GetComponent<BulletBehaviour>().SetDirection(BulletDir);
        AudioManager.instance.PlaySound("ShootBullet");
    }

    public void ShootGranade()
    {
        GameObject shot = PoolingManager.Instance.GetPooledObject("Granade");

        shot.transform.SetPositionAndRotation(shootingPoint.position, shootingPoint.rotation);
        Vector3 GranadeDir = shootingPoint.position - transform.position;
        shot.GetComponent<GranadeBehaviour>().SetDirection(GranadeDir);
        
        granadeAmount--;
        UpdateGranadeAmount(granadeAmount);
    }

    public void UpdateGranadeAmount(int Value)
    {
        granadeAmount = Value;
        UpdateGranadeValue.Invoke(granadeAmount);
    }
}