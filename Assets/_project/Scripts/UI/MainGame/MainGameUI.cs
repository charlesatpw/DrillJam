using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameUI : MonoBehaviour
{
    [SerializeField]
    SliderStatDisplay fuelSliderDisplay;
    [SerializeField]
    SliderStatDisplay healthSliderDisplay;

    [SerializeField]
    StatDisplay currentMDug;
    [SerializeField]
    StatDisplay highscoreMDug;

    [SerializeField]
    WinScreen winScreen;
    [SerializeField]
    DeathScreen deathScreen;

    private void Start()
    {
        currentMDug.SetAmount(LocalPlayerData.instance.localData.currentMScore.ToString());
        highscoreMDug.SetAmount(LocalPlayerData.instance.localData.highestMScore.ToString());

        int playerMaxFuel = Config.playerConfig.maxFuel;
        fuelSliderDisplay.Init(null, 0, playerMaxFuel);

        int playerMaxHealth = Config.playerConfig.maxHealth;
        healthSliderDisplay.Init(null, 0, playerMaxHealth);

        winScreen.gameObject.SetActive(false);
        deathScreen.gameObject.SetActive(false);

        PlayerService.ResetHealth();
        PlayerService.ResetFuel();
        RootUI.instance.NotifyGameUIOfStatChange(PlayerStats.Fuel);
        RootUI.instance.NotifyGameUIOfStatChange(PlayerStats.Health);
    }

    private void OnEnable()
    {
        _ = SubscribePlayerEvents();
    }

    private void OnDisable()
    {
        RootUI.instance.playerDeath -= ShowDeathScreen;
        RootUI.instance.playerWin -= PlayerWon;
    }

    public void UpdateFuelSlider(int fuel)
    {
        fuelSliderDisplay.SetAmount(fuel);
    }

    public void UpdateHealthSlider(int health)
    {
        healthSliderDisplay.SetAmount(health);
    }

    public void UpdateCurrentMetersDugText(int metersDug)
    {
        currentMDug.SetAmount(metersDug, "m", string.Empty);
    }

    public void UpdateHighscoreMetersDugText(int metersDug)
    {
        highscoreMDug.SetAmount(metersDug, "m", "Highscore: ");
    }

    void PlayerWon()
    {
        _ = ShowWinScreen();
    }

    public async UniTask ShowWinScreen()
    {
        winScreen.Init();
        await UniTask.Delay(3000);
        winScreen.gameObject.SetActive(true);

    }

    public void ShowDeathScreen()
    {
        deathScreen.Init();
        deathScreen.gameObject.SetActive(true);
    }

    async UniTask SubscribePlayerEvents()
    {
        await UniTask.WaitUntil(() => RootUI.instance != null);
        RootUI.instance.playerDeath += ShowDeathScreen;
        RootUI.instance.playerWin += PlayerWon;
    }
}
