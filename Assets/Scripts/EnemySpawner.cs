using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefab;
    public float interval = 3.5f;

    void Start()
    {
        StartCoroutine(SpawnEnemy(interval, prefab));
    }

    private IEnumerator SpawnEnemy(float interval,GameObject enemy)
    {
        yield return new WaitForSeconds(interval);

        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f,5f), Random.Range(-6f,6f),0),Quaternion.identity);

        StartCoroutine(SpawnEnemy(interval, enemy));

    }
}
