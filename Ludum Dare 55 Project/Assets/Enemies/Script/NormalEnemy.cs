using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class NormalEnemy : MonoBehaviour
{
    private WagonMovement wagon;
    [SerializeField] private float timetoKill,inFireTimer;
    [SerializeField] AIDestinationSetter AIDestinationSetter;
    [SerializeField] private bool insideFire;
    [SerializeField] private GameObject damageDealer;

    private void Awake()
    {
        wagon = FindObjectOfType<WagonMovement>();
        AIDestinationSetter.target = wagon.transform;
    }

    private void Update()
    {
        if(insideFire)
        {
            inFireTimer += Time.deltaTime;
        }
        if(inFireTimer >= timetoKill)
        {
            DestroyMe(0.0f);
        }

        if (Vector2.Distance(transform.position, wagon.transform.position) < 1.0f)
        {
            Instantiate(damageDealer, transform.position, Quaternion.identity);
            DestroyMe(0.0f);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Fire"))
        {
            insideFire = true;
        }       
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fire"))
        {
            insideFire = false;
        }
    }
    public void DestroyMe(float time)
    {
        Destroy(gameObject, time);
    }
}
