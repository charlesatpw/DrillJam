using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerStats
{
    None,
    Health,
    Fuel,
    MetersDug,
    HighestDug
}

public class RootUI : MonoBehaviour
{
    public static RootUI instance;

    [SerializeField]
    private MainGameUI mainGame;

    private void Awake()
    {
        if (instance)
        {
            Destroy(this);
            return;
        }

        instance = this;
    }

    public MainGameUI GetMainGameUI() 
    { 
        return mainGame; 
    }

    public void NotifyGameUIOfStatChange(PlayerStats stats)
    {
        if (mainGame)
        {
            switch (stats) 
            {
                case PlayerStats.Health:
                    mainGame.UpdateHealthSlider(LocalPlayerData.instance.localData.health);
                    break; 
                case PlayerStats.Fuel:
                    mainGame.UpdateFuelSlider(LocalPlayerData.instance.localData.fuel);
                    break;
                case PlayerStats.MetersDug:
                    mainGame.UpdateCurrentMetersDugText(LocalPlayerData.instance.localData.currentMScore);
                    break;
                case PlayerStats.HighestDug:
                    mainGame.UpdateHighscoreMetersDugText(LocalPlayerData.instance.localData.highestMScore);
                    break;
                default:
#if UNITY_EDITOR
                    Debug.LogWarning("No Player Stat told to update", this);
#endif
                    break;
            }
        }
    }
}
