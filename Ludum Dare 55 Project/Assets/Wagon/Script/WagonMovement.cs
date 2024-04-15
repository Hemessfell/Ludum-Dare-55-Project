using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    public float Speed;

    private void FixedUpdate()
    {
        rb.velocity = Vector2.right * Speed;
        //rb.position = MathExtension.PixelPerfectClamp(rb.position);
    }
}
