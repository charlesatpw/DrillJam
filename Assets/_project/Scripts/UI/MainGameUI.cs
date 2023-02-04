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

        //int playerMaxFuel = Config.playerConfig.;
        //fuelSliderDisplay.Init();
    }
}
