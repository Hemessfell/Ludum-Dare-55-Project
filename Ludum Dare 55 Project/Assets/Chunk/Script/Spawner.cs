using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    GameObject chunk;

    [SerializeField] private Transform[] spawnPoints;

    [SerializeField] private GameObject[] enemies;

    [SerializeField] private int numberOfEnemies;

    private void Awake()
    {
        chunk = transform.parent.gameObject;
       
    }

    public void SpawnEnemy()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Transform _sp = spawnPoints[i];
            GameObject enemyChosen = enemies[Random.Range(0, enemies.Length)];
            Instantiate(enemyChosen, _sp.position, enemyChosen.transform.rotation, chunk.transform);
            /*if (enemyChosen.GetComponent<EnemyBase>() != null)
                enemyChosen.GetComponent<EnemyBase>().chunk = chunk;*/
        }
    }
}