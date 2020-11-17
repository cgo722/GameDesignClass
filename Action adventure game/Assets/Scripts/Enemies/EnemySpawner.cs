using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;

    public float delayTime;

    private WaitForSeconds wfs;

    public IntData enemyCount;
    private void Start()
    {
        enemyCount.value = 0;
        wfs = new WaitForSeconds(delayTime);
    }
    private IEnumerator SpawnEnemy()
    {
        while (enemyCount.value < 6)
        {
            yield return wfs;
            Instantiate(enemy, transform.position, Quaternion.identity);
            enemyCount.value++;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(SpawnEnemy());
        }
    }

    private void ontriggerexit(Collider other)
    {
        StopCoroutine(SpawnEnemy());
    }
}
