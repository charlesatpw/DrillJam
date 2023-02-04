using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerService
{
    public static void IncreaseStat(PlayerStats statToIncrease, int amount, bool save = false)
    {
        if (!RootUI.instance || LocalPlayerData.instance == null)
        {
            return;
        }

        switch (statToIncrease)
        {
            case PlayerStats.Health:
                LocalPlayerData.instance.localData.health += amount;
                Mathf.Clamp(LocalPlayerData.instance.localData.health, 0, Config.playerConfig.maxHealth);
                break;
            case PlayerStats.Fuel:
                LocalPlayerData.instance.localData.fuel += amount;
                Mathf.Clamp(LocalPlayerData.instance.localData.fuel, 0, Config.playerConfig.maxFuel);
                break;
            case PlayerStats.MetersDug:
                LocalPlayerData.instance.localData.currentMScore += amount;
                break;
            case PlayerStats.HighestDug:
                LocalPlayerData.instance.localData.highestMScore += amount;
                break;
            default:
                break;
        }

        RootUI.instance.NotifyGameUIOfStatChange(statToIncrease);

        if (save)
        {
            LocalPlayerData.SaveData();
        }
    }

    public static void DecreaseStat(PlayerStats statToDecrease, int amount, bool save = false) 
    {
        IncreaseStat(statToDecrease, amount * -1, save);
    }

    public static bool isStatAtMax(PlayerStats stat)
    {
        switch (stat)
        {
            case PlayerStats.Health:
                return (LocalPlayerData.instance.localData.health == Config.playerConfig.maxHealth);
            case PlayerStats.Fuel:
                return (LocalPlayerData.instance.localData.fuel == Config.playerConfig.maxFuel);
            default: 
                return false;
        }
    }
}
