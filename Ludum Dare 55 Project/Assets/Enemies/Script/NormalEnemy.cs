using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class NormalEnemy : MonoBehaviour
{
    private WagonMovement wagon;
    [SerializeField] AIDestinationSetter AIDestinationSetter;
    private void Awake()
    {
        wagon = FindObjectOfType<WagonMovement>();
        AIDestinationSetter.target = wagon.transform;
    }
    public void DestroyMe(float time)
    {
        Destroy(gameObject, time);
    }
}
