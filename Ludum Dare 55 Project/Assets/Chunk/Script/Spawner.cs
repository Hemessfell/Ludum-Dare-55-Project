using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    GameObject chunk;

    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private GameObject[] enemies;


    [SerializeField] private int numberOfEnemies;

    [SerializeField] private float timeToSpawn;

    private void Awake()
    {
        chunk = transform.parent.gameObject;
        transform.SetParent(null);
    }

    public IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject enemyChosen = enemies[Random.Range(0, enemies.Length)];
            Instantiate(enemyChosen, _sp.position, enemyChosen.transform.rotation, transform);
            yield return new WaitForSeconds(timeToSpawn);
        }
    }
}