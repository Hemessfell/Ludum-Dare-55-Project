using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb;

    private int walkHash;

    private void Awake()
    {
        walkHash = Animator.StringToHash("runSpeed");
    }

    private void Update()
    {
        if(Mathf.Abs(rb.velocity.x) > 0)
            transform.parent.localScale = new Vector3(Sign(rb.velocity.x), 1.0f, 1.0f);

        CheckPlayerAnimations();
    }

    private void CheckPlayerAnimations()
    {
        anim.SetFloat(walkHash, Mathf.Abs(rb.velocity.x) == 0.0f ? Mathf.Abs(rb.velocity.y) : Mathf.Abs(rb.velocity.x));
    }

    private int Sign(float value)
    {
        int sign = 0;

        if (value < 0)
            sign = -1;

        if (value > 0)
            sign = 1;

        if (value == 0)
            sign = 0;

        return sign;
    }
}
