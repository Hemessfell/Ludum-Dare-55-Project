using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemy : MonoBehaviour
{
    [SerializeField] private float shootInterval, radius;
    [SerializeField] private GameObject projectile;
    private bool recharge,isplayerIn;
    private Coroutine coroutine;
    [SerializeField] private LayerMask whatIsPlayer;


    private void Update()
    {
        isplayerIn = Physics2D.OverlapCircle(transform.position, radius, whatIsPlayer);
        if(isplayerIn && !recharge)
        {
            coroutine = StartCoroutine(Shoot());
        }
    }
  /*  private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wagon") && !recharge)
        {
            coroutine = StartCoroutine(Shoot());
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wagon")) 
        {
            StopCoroutine(coroutine);
        }
    }*/
    private IEnumerator Shoot()
    {
        recharge = true;
        yield return new WaitForSeconds(shootInterval);
        Instantiate(projectile, transform.position, Quaternion.identity);
        recharge = false;
    }
    public  void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
