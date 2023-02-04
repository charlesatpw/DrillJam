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

    private void Start()
    {
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
        currentMDug.SetAmount(metersDug);
    }

    public void UpdateHighscoreMetersDugText(int metersDug)
    {
        highscoreMDug.SetAmount(metersDug);
    }
}
