using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Camera cam;

    [SerializeField] private float speed;
    void Start()
    {
        rb.velocity = Vector2.right * speed;
        cam.transform.position = transform.position;
    }

    void Update()
    {
        cam.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
    }
}
