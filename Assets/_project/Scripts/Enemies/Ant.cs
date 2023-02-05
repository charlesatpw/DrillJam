using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : EnemyController
{
    public Tunnel tunnel;

    public SpriteRenderer sprite;

    private Vector3[] linePoints;

    private int lastPoint = 0;

    private float distanceAlongCurrentSegment = 0f;

    private float lineWidth;

    private void Update()
    {
        Movement(speed * Time.deltaTime);
    }

    public void Init(Tunnel tunnel, bool flipped)
    {
        this.tunnel = tunnel;
        linePoints = this.tunnel.GetPoints();
        transform.position = new Vector3(transform.position.x, transform.position.y, 0.1f);
        lineWidth = tunnel.GetWidth() * 0.5f;
        sprite.flipX = flipped;
    }

    protected void Movement(float moveDistance)
    {
        if (lastPoint == linePoints.Length)
        {
            Destroy(gameObject);
            return;
        }

        // Get Current Direction
        Vector3 line = GetLine();

        // if would be at new point update point and move the rest of the distance
        if (distanceAlongCurrentSegment + moveDistance > line.magnitude)
        {
            distanceAlongCurrentSegment = 0;
            lastPoint += 1;
            Movement(moveDistance);
            return;
        }

        // Move towards direction
        distanceAlongCurrentSegment += moveDistance;
        transform.position = linePoints[lastPoint] + (line.normalized) * distanceAlongCurrentSegment;
        transform.position += Vector3.forward * -0.01f;
        transform.position += Vector3.up * -lineWidth;
    }

    protected Vector3 GetLine()
    {
        if (lastPoint + 1 >= linePoints.Length)
        {
            return Vector3.zero;
        }
        return (linePoints[lastPoint + 1] - linePoints[lastPoint]);
    }
}
