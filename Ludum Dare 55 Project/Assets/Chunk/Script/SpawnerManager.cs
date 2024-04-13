using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private Spawner[] spawners;

    [SerializeField] private BoxCollider2D boxCollider;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Wagon"))
        {
            Debug.Log("salve");
            for(int i = 0; i < spawners.Length; i++)
            {
                spawners[i].SpawnEnemy();
            }
        }
    }
}
