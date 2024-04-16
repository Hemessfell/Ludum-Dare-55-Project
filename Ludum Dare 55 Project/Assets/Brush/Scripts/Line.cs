using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private EdgeCollider2D edgeCollider;
    [SerializeField] private BrushManager brushManager;

    private readonly List<Vector2> points = new List<Vector2>();
    public void SetPostion(Vector2 pos)
    {
        if (!CanAppend(pos)) return;

        //points.Add(pos);

        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount - 1 , pos);

        //edgeCollider.points = points.ToArray();
    }
    private bool CanAppend(Vector2 pos)
    {
        if (lineRenderer.positionCount == 0)
            return true;

        return Vector2.Distance(lineRenderer.GetPosition(lineRenderer.positionCount - 1), pos) > DrawManager.RESOLUTION;
    }
}
