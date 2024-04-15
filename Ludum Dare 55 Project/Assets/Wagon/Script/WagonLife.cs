using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WagonLife : MonoBehaviour
{
    [SerializeField] private float life;
    [SerializeField] private Animator anim;
    [SerializeField] private Slider slider;

    private int lifeAnimatorVariableHash;

    private void Awake()
    {
        lifeAnimatorVariableHash = Animator.StringToHash("Life");
    }

    public void DecreaseLife(float decreasingValue)
    {
        life -= decreasingValue;
        anim.SetFloat(lifeAnimatorVariableHash, life);
        slider.value = life;    

        if (life <= 0.0f)
            Die();
    }

    private void Die()
    {

    }
}
