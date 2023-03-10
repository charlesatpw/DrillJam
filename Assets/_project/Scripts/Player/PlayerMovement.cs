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
    [SerializeField] 
    Transform bottomOfMapObject;

    [SerializeField]
    public BoxCollider2D levelBoundingBox;

    private void Start()
    {
        SoundManager.instance.PlayClipWithSource(SoundManager.SoundClip.Drill, SoundManager.instance.loopSource);
    }

    public void Update()
    {
        if (transform.position.x < levelBoundingBox.bounds.min.x)
        {
            leftRightAxis = 1;
        }
        else if (transform.position.x > levelBoundingBox.bounds.max.x)
        {
            leftRightAxis = -1;
        }

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

        //Meters dug calculations
        LocalPlayerData.instance.localData.currentMScore = Mathf.RoundToInt(LevelService.GetMetersFromTop(topOfMapObject, transform.position.y));
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

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            transform.position = new Vector3(transform.position.x, bottomOfMapObject.position.y, transform.position.z);
            RootUI.instance.CallPlayerWin();
        }
#endif
    }

    public void OnAxis(InputAction.CallbackContext callbackContext)
    {
        leftRightAxis = callbackContext.ReadValue<float>();
        
    }
}
