using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SaveDuringPlay]
[AddComponentMenu("")] // Hide in menu
public class CinemachineAxisLimiter : CinemachineExtension
{
    [Tooltip("Lock the camera's Z position to this value")]
    public float m_ZPosition = 10;
    [Tooltip("Lock the camera's X position to this value")]
    public float m_XPosition = 10;

    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (enabled && stage == CinemachineCore.Stage.Body)
        {
            var pos = state.RawPosition;
            pos.z = m_ZPosition;
            pos.x = m_XPosition;
            state.RawPosition = pos;
        }
    }
}
