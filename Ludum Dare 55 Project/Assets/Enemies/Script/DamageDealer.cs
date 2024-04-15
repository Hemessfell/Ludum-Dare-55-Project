using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
       WagonLife wagon = other.GetComponent<WagonLife>(); 

       if(wagon)
       {
            wagon.DecreaseLife(damage);
       }
    }
}
