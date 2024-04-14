using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemy : MonoBehaviour
{
    [SerializeField] private float shootInterval;
    [SerializeField] private GameObject projectile;
    [SerializeField] private CircleCollider2D circleCollider2D;
    private bool recharge;
    private Coroutine coroutine;


    private void OnTriggerStay2D(Collider2D other)
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
    }
    private IEnumerator Shoot()
    {
        recharge = true;
        yield return new WaitForSeconds(shootInterval);
        Instantiate(projectile, transform.position, Quaternion.identity);
        recharge = false;
    }
}
