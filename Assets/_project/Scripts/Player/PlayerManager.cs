using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private PlayerMovement playerMovement;
    [SerializeField]
    private PlayerTriggerManager playerTriggerManager;

    [SerializeField]
    private PlayerInput playerInput;

    public bool playerEnabled = true;

    private void Start()
    {
        _ = DepleteFuel();
    }

    private void OnEnable()
    {
        _ = SubscribePlayerEvents();
    }

    private void OnDisable()
    {
        if (RootUI.instance)
        {
            RootUI.instance.playerDeath -= DisablePlayer;
            RootUI.instance.playerWin -= DisablePlayer;
        }
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
        playerInput.DeactivateInput();
    }

    public void EnablePlayer()
    {
        playerEnabled = true;

        playerMovement.enabled = true;
        playerTriggerManager.enabled = true;
        playerInput.ActivateInput();
    }

    async UniTask SubscribePlayerEvents()
    {
        await UniTask.WaitUntil(() => RootUI.instance != null);
        RootUI.instance.playerDeath += DisablePlayer;
        RootUI.instance.playerWin += DisablePlayer;
    }
}
