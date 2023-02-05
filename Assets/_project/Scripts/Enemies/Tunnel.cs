using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tunnel : MonoBehaviour
{
    [SerializeField]
    private LineRenderer lineRenderer;

    public GameObject spawnedEnemy;

    public bool leftToRigt;

    public float spawnRates;

    public void Init(Vector3[] pointsForLine, bool leftToRigt)
    {
        this.leftToRigt = leftToRigt;
        lineRenderer.positionCount = pointsForLine.Length;
        lineRenderer.SetPositions(pointsForLine);
        StartCoroutine(WaitAndSpawn());
    }

    public Vector3[] GetPoints()
    {
        Vector3[] points = new Vector3[lineRenderer.positionCount];
        lineRenderer.GetPositions(points);
        return points;
    }

    public float GetWidth()
    {
        return lineRenderer.widthMultiplier;
    }

    public IEnumerator WaitAndSpawn()
    {
        SpawnEnemy();
        yield return new WaitForSeconds(spawnRates);
        StartCoroutine(WaitAndSpawn());
    }

    private void SpawnEnemy()
    {
        if (spawnedEnemy != null)
        {
            GameObject.Instantiate(spawnedEnemy, lineRenderer.GetPosition(0), new Quaternion(0, 0, 0, 0), transform)
                .GetComponent<Ant>().Init(this, leftToRigt);
        }
    }
}
