using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tunnel : MonoBehaviour
{
    [SerializeField]
    private LineRenderer lineRenderer;

    public void Init(Vector3[] pointsForLine)
    {
        lineRenderer.positionCount = pointsForLine.Length;
        lineRenderer.SetPositions(pointsForLine);
    }
}
