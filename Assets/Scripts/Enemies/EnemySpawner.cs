using System.Collections;
using Unity.VisualScripting;
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
    public int maxEnemies;
    public float spawnInterval;
    private int currentEnemyCount;

    void Update()
    {
        if(currentEnemyCount < maxEnemies)
        {
            StartCoroutine(SpawnEnemies());
        }
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            if (currentEnemyCount < maxEnemies)
            {
                SpawnEnemy();
            }
        }
    }

    void SpawnEnemy()
    {
        if (spawnPoints.Length == 0)
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