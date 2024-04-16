using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    [SerializeField] private GameObject lightningCircle;
    [SerializeField] private TurretEnemy turretEnemy;
    [SerializeField] private NormalEnemy normalEnemy;
    void Start()
    {
        lightningCircle.transform.parent = null;
        if (normalEnemy != null)
            normalEnemy.DestroyMe(0.25f);
        if (turretEnemy != null)
            turretEnemy.DestroyMe(0.25f);
    }
}
