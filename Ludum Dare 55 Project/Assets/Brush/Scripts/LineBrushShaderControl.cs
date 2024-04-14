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
                //StartCoroutine(RemovePoints());
            }
        }

    }

    /*private IEnumerator RemovePoints()
    {
        List<Vector2> points = new List<Vector2>();
        points = edgeCollider.points;
        for (int i = 0;i < edgeCollider.pointCount;i++)
        {
            points.RemoveRange(i,i);
            edgeCollider.points = points.ToArray();
            yield return new WaitForSeconds(1.65f / edgeCollider.pointCount);
        }
    }*/
    private IEnumerator TimeToStartFading()
    {
        started = true;
        yield return new WaitForSeconds(waitTime);
        canFade = true;
    }
}
