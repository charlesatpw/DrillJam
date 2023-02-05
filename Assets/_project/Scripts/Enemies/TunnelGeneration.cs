using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelGeneration : MonoBehaviour
{
    public BoxCollider2D levelbounds;

    public Transform playerTransform;

    public GameObject tunnelPrefab;

    public float spawnDistanceFromPlayer = 1f;

    public float baseSegmentLength = 1f;

    public float segmentLengthVariation = 1f;
    public float segmentangAngleVariation = 1f;

    public void Start()
    {
        for (int i = 0; i < 10; ++i)
        {
            GenerateTunnel(i * 20);
        }
    }

    public void GenerateTunnel(float yPlus)
    {
        // Coin-Flip for left to right or right to left
        bool leftToRight = Random.Range(0, 2) == 0;
        float xPosition = leftToRight ? levelbounds.bounds.min.x - 10 : levelbounds.bounds.max.x + 10;

        // Select starting point
        List<Vector3> points = new List<Vector3>();
        Vector3 startingPoint = new Vector3(xPosition, playerTransform.position.y + spawnDistanceFromPlayer - yPlus, 0);
        points.Add(startingPoint);
        if (leftToRight)
        {
            while (points[points.Count - 1].x < levelbounds.bounds.max.x + 10)
            {
                points.Add(SelectNextPoint(leftToRight, points[points.Count - 1]));
            }
        }
        else
        {
            while (points[points.Count - 1].x > levelbounds.bounds.min.x - 10)
            {
                points.Add(SelectNextPoint(leftToRight, points[points.Count - 1]));
            }
        }
        Instantiate(tunnelPrefab, startingPoint, new Quaternion(0, 0, 0, 0), transform).GetComponent<Tunnel>().Init(points.ToArray());
    }

    public Vector3 SelectNextPoint(bool leftToRight, Vector3 startingPoint)
    {
        float xValue = leftToRight ? 1f : -1f;
        float yValue = Random.Range(-1f, 1f);
        Vector3 direction = new Vector3(xValue, yValue, 0f);

        return startingPoint += direction.normalized * (baseSegmentLength + segmentLengthVariation);
    }
}
