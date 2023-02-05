using Cysharp.Threading.Tasks;
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

    public bool playerEnabled = true;

    private void Start()
    {
        _ = DepleteFuel();
    }

    private void OnEnable()
    {
        RootUI.instance.playerDeath += DisablePlayer;
        RootUI.instance.playerWin += DisablePlayer;
    }

    private void OnDisable()
    {
        RootUI.instance.playerDeath -= DisablePlayer;
        RootUI.instance.playerWin -= DisablePlayer;
    }

    async UniTask DepleteFuel()
    {
        if (!playerEnabled)
        {
            await UniTask.Yield();
        }

        while (playerEnabled)
        {
            await UniTask.Delay(1000);
            //Updating fuel
            PlayerService.DecreaseStat(PlayerStats.Fuel, Config.rootConfig.fuelLossRate, false);
        }

        _ = DepleteFuel();
    }

    public void DisablePlayer()
    {
        playerEnabled = false;
        playerMovement.enabled = false;
        playerTriggerManager.enabled = false;
    }

    public void EnablePlayer()
    {
        playerEnabled = true;

        playerMovement.enabled = true;
        playerTriggerManager.enabled = true;
    }
}
