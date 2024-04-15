using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class LineBrushShaderControl : MonoBehaviour
{
    [SerializeField] private float waitTime;
    [SerializeField] private float timeToFade;

    private float normalizedAlphaValue;
    private bool canFade, started;

    private LineRenderer lineRenderer;
    private Material myMaterial;

    private EdgeCollider2D edgeCollider;


    private void Awake()
    {
        edgeCollider = GetComponent<EdgeCollider2D>();
        lineRenderer = GetComponent<LineRenderer>();
        myMaterial = lineRenderer.material;
    }

    private void Update()
    {
        if (canFade)
        {
            normalizedAlphaValue = Mathf.MoveTowards(normalizedAlphaValue, 1.65f, timeToFade * Time.deltaTime);

            myMaterial.SetFloat("_AlphaCut", normalizedAlphaValue);

            if (normalizedAlphaValue >= 1.65f)
            {
                gameObject.SetActive(false);
                AstarPath.UpdateGraph();
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            if(!started)
            {
                StartCoroutine(TimeToStartFading());
            }
        }

    }
    private IEnumerator TimeToStartFading()
    {
        started = true;
        yield return new WaitForSeconds(waitTime);
        canFade = true;
    }
}
