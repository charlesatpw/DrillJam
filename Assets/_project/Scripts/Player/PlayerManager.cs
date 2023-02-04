using Cysharp.Threading.Tasks.Triggers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playerMovement;
    [SerializeField]
    private PlayerTriggerManager playerTriggerManager;

    public void DisablePlayer()
    {
        playerMovement.enabled = false;
        playerTriggerManager.enabled = false;
    }

    public void EnablePlayer()
    {
        playerMovement.enabled = true;
        playerTriggerManager.enabled = true;
    }
}
