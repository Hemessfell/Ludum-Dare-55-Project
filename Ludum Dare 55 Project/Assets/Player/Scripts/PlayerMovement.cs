using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;

    private Vector2 target;
    private Vector2 direction;

    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, target) > 0.1f)
        {
            rb.velocity = direction * moveSpeed;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            target = Helpers.WorldMousePosition();
            direction = -((Vector2)transform.position - target).normalized;
        }
    }
}
