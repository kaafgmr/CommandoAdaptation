using System.Collections;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public int EnemiesToSpawn;
    public float timeToSpawn;
    public GameObject EnemyPrefab;

    private void OnBecameVisible()
    {
        gameObject.SetActive(true);
        StartCoroutine(EnemySpawner());
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    IEnumerator EnemySpawner()
    {
        SpawnEnemy();
        EnemiesToSpawn--;
        yield return new WaitForSeconds(timeToSpawn);
        if(EnemiesToSpawn > 0)
        {
            StartCoroutine(EnemySpawner());
        }
        else
        {
            StopCoroutine(EnemySpawner());
        }
    }

    public void SpawnEnemy()
    {
        GameObject Enemy = Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
        Enemy.SetActive(true);
    }
}
