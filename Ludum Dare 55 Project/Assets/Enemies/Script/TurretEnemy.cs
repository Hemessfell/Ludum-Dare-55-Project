using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemy : MonoBehaviour
{
    [SerializeField] private float shootInterval, radius;
    [SerializeField] private float timetoKill, inFireTimer;
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject damageDealer;
    private bool recharge,isplayerIn;
        [SerializeField] private bool insideFire;
    private Coroutine coroutine;
    [SerializeField] private LayerMask whatIsPlayer;

    private WagonLife wagon;

    private void Awake()
    {
        wagon = FindObjectOfType<WagonLife>();
    }

    private void Update()
    {
        isplayerIn = Physics2D.OverlapCircle(transform.position, radius, whatIsPlayer);
        if(isplayerIn && !recharge)
        {
            coroutine = StartCoroutine(Shoot());
        }

        if (Vector2.Distance(transform.position, wagon.transform.position) < 0.5f)
        {
            Instantiate(damageDealer, transform.position, Quaternion.identity);
            DestroyMe(0.0f);
        }

        if (insideFire)
        {
            inFireTimer += Time.deltaTime;
        }

        if (inFireTimer >= timetoKill)
        {
            DestroyMe(0.0f);
        }
    }

    private IEnumerator Shoot()
    {
        recharge = true;
        yield return new WaitForSeconds(shootInterval);
        Instantiate(projectile, transform.position, Quaternion.identity);
        recharge = false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    public void DestroyMe(float time)
    {
        Destroy(gameObject, time);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fire"))
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
}
