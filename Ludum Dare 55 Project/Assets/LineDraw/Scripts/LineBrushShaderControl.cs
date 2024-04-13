using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBrushShaderControl : MonoBehaviour
{
    [SerializeField] private float waitTime;
    [SerializeField] private float timeToFade;

    private float normalizedAlphaValue;
    private bool canFade;

    private LineRenderer lineRenderer;
    private Material myMaterial;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        myMaterial = lineRenderer.material;

        StartCoroutine(TimeToStartFading());
    }

    private void Update()
    {
        if (canFade)
        {
            normalizedAlphaValue = Mathf.MoveTowards(normalizedAlphaValue, 1.65f, timeToFade * Time.deltaTime);

            myMaterial.SetFloat("_AlphaCut", normalizedAlphaValue);
        }
    }

    private IEnumerator TimeToStartFading()
    {
        yield return new WaitForSeconds(waitTime);
        canFade = true;
    }
}
