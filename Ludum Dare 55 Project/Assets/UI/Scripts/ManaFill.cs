using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaFill : MonoBehaviour
{
    [SerializeField] RectTransform rectTransform;
    [SerializeField, Range(0, 1)] private float manaAmmount;

    private float initialHeight;
    private bool reachedZero;

    private void Awake()
    {
        initialHeight = rectTransform.sizeDelta.y;
    }

    private void Update()
    {
        rectTransform.sizeDelta = new Vector3(rectTransform.sizeDelta.x, Mathf.Lerp(0.0f, initialHeight, manaAmmount));
    }

    public void DecreaseMana(float decreaseValue)
    {
        manaAmmount -= decreaseValue;
        manaAmmount = Mathf.Clamp01(manaAmmount);
        rectTransform.sizeDelta = new Vector3(rectTransform.sizeDelta.x, Mathf.Lerp(0.0f, initialHeight, manaAmmount));

        if(manaAmmount == 0.0f)
        {
            reachedZero = true;
        }
    }

    public void IncreaseMana(float increaseValue)
    {
        manaAmmount += increaseValue;
        manaAmmount = Mathf.Clamp01(manaAmmount);
        rectTransform.sizeDelta = new Vector3(rectTransform.sizeDelta.x, Mathf.Lerp(0.0f, initialHeight, manaAmmount));
        reachedZero = false;
    }
}
