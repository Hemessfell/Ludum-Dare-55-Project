using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterSeconds : MonoBehaviour
{
    [SerializeField] private float timeToDestroy;
    [SerializeField] private GameObject gore;
    [SerializeField] private DestroyParent parent;
    private void OnEnable()
    {
        parent.DestroyMe(timeToDestroy);
    }
    private void OnDestroy()
    {
        Instantiate(gore,transform.position,Quaternion.identity);
    }
}
