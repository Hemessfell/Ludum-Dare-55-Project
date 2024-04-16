using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using DG.Tweening;

public class CicleCast : MonoBehaviour
{
    [SerializeField] float fadeTimer = 1;
    [SerializeField] SpriteRenderer spr;
    private bool once;


    private void Start()
    {
        spr.DOColor(new Color(1, 1, 1, 1), fadeTimer);
        transform.DOScale(new Vector3(1, 1, 1), 1);
    }
    private void Update()
    {
        if (transform.parent == null && !once)
        {
            DoFadeOut();
        }
    }

    private void DoFadeOut()
    {
        once = true;
        spr.DOColor(new Color(1, 1, 1, 0), fadeTimer);
        transform.DOScale(new Vector3(0, 0, 0), 1);
        Destroy(gameObject,fadeTimer);
    }
}
