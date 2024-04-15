using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeWall : MonoBehaviour
{
    [SerializeField] SpriteRenderer spr;
    private void Start()
    {
        spr.DOColor(new Color(1, 1, 1, 1), 1f);
        transform.DOScale(new Vector3(1, 1, 1), 1);

    }
    public void FadeOut()
    {
        spr.DOColor(new Color(1, 1, 1, 0), 1f);
        transform.DOScale(new Vector3(0,0, 0), 1);
    }
}
