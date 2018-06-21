using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Line : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public EdgeCollider2D edgeCol;

    List<Vector2> points;
    public void updateLine(Vector2 mousePos)
    {
        if (points == null)
        {
            points = new List<Vector2>();
            SetPoint(mousePos);
            return;
        }
        if (Vector2.Distance(points.Last(), mousePos) > .2f && Vector2.Distance(points.First(), mousePos) < 8f)
        {
            SetPoint(mousePos);
        }
    }
    void SetPoint(Vector2 point)
    {
        points.Add(point);
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);

        if (points.Count > 1)
        {
            edgeCol.points = points.ToArray();
        }
    }
}
