using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    [SerializeField] private float timeToDestroy;
    [SerializeField] private GameObject gore;
    private void OnEnable()
    {
        Destroy(gameObject, timeToDestroy);
    }
    private void OnDestroy()
    {
        Instantiate(gore,transform.position,Quaternion.identity);
    }
}
