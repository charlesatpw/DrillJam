using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    float leftRightAxis;

    public float currentRotation = 0f;

    public LineRenderer lineRenderer;

    [SerializeField]
    Transform topOfMapObject;

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
        transform.position += transform.up * -1f * Time.deltaTime * Config.playerConfig.forwardSpeed;

        LocalPlayerData.instance.localData.currentMScore = Mathf.Abs((int)(transform.position.y + Mathf.Abs(topOfMapObject.position.y)));
        RootUI.instance.NotifyGameUIOfStatChange(PlayerStats.MetersDug);

        if (PlayerService.HasPlayerBrokenRecord())
        {
            LocalPlayerData.instance.localData.highestMScore = LocalPlayerData.instance.localData.currentMScore;
            RootUI.instance.NotifyGameUIOfStatChange(PlayerStats.HighestDug);

            if (!PlayerService.instance.highestMeterRecordBroken)
            {
                SoundManager.instance.PlayClip(SoundManager.SoundClip.BeatPBNoise);
                PlayerService.instance.highestMeterRecordBroken = true;
            }
        }
    }

    public void OnAxis(InputAction.CallbackContext callbackContext)
    {
        leftRightAxis = callbackContext.ReadValue<float>();
        
    }
}
