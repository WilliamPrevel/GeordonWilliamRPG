using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject AnEnemy;
    public MultiPurposePool thePool;

    void Start()
    {
        StartCoroutine(SpawnTimer());
    }

    IEnumerator SpawnTimer()
    {
        while (true)
        {
            Spawn(AnEnemy);

            yield return new WaitForSeconds(10f);
        }
    }

    void Spawn(GameObject enemy)
    {
        float randomZ = Random.Range(-100f, 100f);
        float randomX = Random.Range(-100f, 100f);

        GameObject newEnemy = thePool.GetPooledObject();
        newEnemy.transform.position = new Vector3(randomX, 10, randomZ);
        newEnemy.SetActive(true);
    }
}
