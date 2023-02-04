using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    float leftRightAxis;

    public float currentRotation = 0f;

    public LineRenderer lineRenderer;

    public void Update()
    {
        float rotationChange = leftRightAxis * Time.deltaTime * Config.playerConfig.turnSpeed;
        if (currentRotation + rotationChange > Config.playerConfig.maxRotationAngle)
        {
            rotationChange = Config.playerConfig.maxRotationAngle - currentRotation;
            currentRotation = Config.playerConfig.maxRotationAngle;
        }
        else if (currentRotation + rotationChange < -Config.playerConfig.maxRotationAngle)
        {
            rotationChange = -Config.playerConfig.maxRotationAngle - currentRotation;
            currentRotation = -Config.playerConfig.maxRotationAngle;
        }
        else
        {
            currentRotation += rotationChange;
        }
        transform.Rotate(0, 0, rotationChange);

        Debug.Log(currentRotation);

        transform.position += transform.up * -1f * Time.deltaTime * Config.playerConfig.forwardSpeed;
    }

    public void OnAxis(InputAction.CallbackContext callbackContext)
    {
        leftRightAxis = callbackContext.ReadValue<float>();
        
    }
}
