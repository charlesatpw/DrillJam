using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BranchTiling : MonoBehaviour
{
    public TrailRenderer trailRender;

    public int currentPositon;
    public float length;

    private Vector3 lastPosition;

    public void Update()
    {
        if (trailRender.positionCount > currentPositon)
        {
            for (; currentPositon < trailRender.positionCount; ++currentPositon)
            {
                length += (trailRender.GetPosition(currentPositon) - lastPosition).magnitude;
                lastPosition = trailRender.GetPosition(currentPositon);
            }
        }

        trailRender.material.mainTextureScale = new Vector2(length * 0.05f, 1f);
    }
}
