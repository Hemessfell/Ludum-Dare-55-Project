using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    private WagonMovement target ;
    [SerializeField] private float force;
    [SerializeField] private GameObject damageDealer;

    private void Awake()
    {
        target = FindObjectOfType<WagonMovement>();
        Destroy(gameObject, 6f);
    }
    private void Start()
    {
        ThorwItself();
    }
    private void ThorwItself()
    {
        Vector2 direction = new Vector2(target.transform.position.x + ((transform.position - target.transform.position).magnitude/ force * 200 *(target.Speed/3)), target.transform.position.y) - new Vector2( transform.position.x,transform.position.y);
        direction.Normalize();
        rb.AddForce(direction * force);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wagon") || other.gameObject.layer == 6)
        {
            Instantiate(damageDealer, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
