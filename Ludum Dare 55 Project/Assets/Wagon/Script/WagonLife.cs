using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WagonLife : MonoBehaviour
{
    [SerializeField] private float life;
    [SerializeField] private Animator anim;
    [SerializeField] private Slider slider;
    [SerializeField] private Rigidbody2D rb;

    private int lifeAnimatorVariableHash;
    private bool isDead;
    Vector3 deadPosition;

    private void Awake()
    {
        lifeAnimatorVariableHash = Animator.StringToHash("Life");
    }

    private void Update()
    {
        if (isDead)
        {
            transform.position = deadPosition;
        }
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
        rb.velocity = Vector2.zero;
        StartCoroutine(TimeToDie());
        isDead = true;
        deadPosition = transform.position;

        IEnumerator TimeToDie()
        {
            yield return Helpers.GetWait(2);
            SceneManager.LoadScene(0);
        }
    }
}
