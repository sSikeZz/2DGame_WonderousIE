using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class EnemyType
    {
        public GameObject enemyPrefab;
        public int spawnWeight;
    }

    public EnemyType[] enemies;
    public Transform[] spawnPoints;
    public int maxEnemies = 10;
    public float spawnInterval = 2f;
    private int currentEnemyCount = 0;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            if (currentEnemyCount < maxEnemies)
            {
                //Debug.Log("calling");
                SpawnEnemy();
            }
        }
    }

    void SpawnEnemy()
    {
        if (enemies.Length == 0 || spawnPoints.Length == 0)
            return;

        EnemyType selectedEnemy = GetRandomEnemy();
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(selectedEnemy.enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        currentEnemyCount++;
    }

    EnemyType GetRandomEnemy()
    {
        int totalWeight = 0;
        foreach (var enemy in enemies)
        {
            totalWeight += enemy.spawnWeight;
        }

        int randomValue = Random.Range(0, totalWeight);
        foreach (var enemy in enemies)
        {
            if (randomValue < enemy.spawnWeight)
                return enemy;
            randomValue -= enemy.spawnWeight;
        }
        return enemies[0];
    }

   
}