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
        fuelSliderDisplay.Init(null, 0, playerMaxHealth);
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

    public void ShowWinScreen()
    {
        winScreen.gameObject.SetActive(true);
    }

    public void ShowDeathScreen()
    {
        deathScreen.gameObject.SetActive(true);
    }
}
