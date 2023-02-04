using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int health;
    public int fuel;
    public int highestMScore;
    public int currentMScore;

    public PlayerData()
    {
        health = 0;
        fuel = 0;
        highestMScore = 0;
        currentMScore = 0;
    }

    public PlayerData(PlayerData otherData)
    {
        health = otherData.health;
        fuel = otherData.fuel;
        highestMScore = otherData.highestMScore;
        currentMScore = otherData.currentMScore;
    }

    public void ResetPlayerData(PlayerData otherData)
    {
        otherData = new PlayerData();
    }
}
