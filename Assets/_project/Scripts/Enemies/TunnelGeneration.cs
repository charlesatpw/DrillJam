using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelGeneration : MonoBehaviour
{
    public BoxCollider2D levelbounds;

    public Transform playerTransform;

    float lastSpawnY = 0;

    public GameObject tunnelPrefab;
    public GameObject moleTunnelPrfab;

    public float spawnDistanceFromPlayer = 1f;

    public float baseSegmentLength = 1f;

    public float segmentLengthVariation = 1f;
    public float segmentangAngleVariation = 1f;

    public float boundsOffset;

    private void Update()
    {
        if (lastSpawnY > playerTransform.position.y - spawnDistanceFromPlayer)
        {
            lastSpawnY -= Random.Range(-5f, 5f) + spawnDistanceFromPlayer;
            GenerateTunnel();
        }
    }

    public void GenerateTunnel()
    {
        // Coin-Flip for left to right or right to left
        bool leftToRight = Random.Range(0, 2) == 0;
        float xPosition = leftToRight ? levelbounds.bounds.min.x - boundsOffset : levelbounds.bounds.max.x + boundsOffset;

        // Select starting point
        List<Vector3> points = new List<Vector3>();
        Vector3 startingPoint = new Vector3(xPosition, (playerTransform.position.y - spawnDistanceFromPlayer) + lastSpawnY, 0);
        points.Add(startingPoint);
        if (leftToRight)
        {
            while (points[points.Count - 1].x < levelbounds.bounds.max.x + boundsOffset)
            {
                points.Add(SelectNextPoint(leftToRight, points[points.Count - 1]));
            }
        }
        else
        {
            while (points[points.Count - 1].x > levelbounds.bounds.min.x - boundsOffset)
            {
                points.Add(SelectNextPoint(leftToRight, points[points.Count - 1]));
            }
        }

        int choice = Random.Range(0, 100);

        if (choice < 75)
        {
            Instantiate(tunnelPrefab, startingPoint, new Quaternion(0, 0, 0, 0), transform).GetComponent<Tunnel>().Init(points.ToArray(), leftToRight);
        }
        else
        {
            Instantiate(moleTunnelPrfab, startingPoint, new Quaternion(0, 0, 0, 0), transform).GetComponent<Tunnel>().Init(points.ToArray(), leftToRight);
        }
    }

    public Vector3 SelectNextPoint(bool leftToRight, Vector3 startingPoint)
    {
        float xValue = leftToRight ? 1f : -1f;
        float yValue = Random.Range(-1f, 1f);
        Vector3 direction = new Vector3(xValue, yValue, -0.01f);

        return startingPoint += direction.normalized * (baseSegmentLength + segmentLengthVariation);
    }
}
