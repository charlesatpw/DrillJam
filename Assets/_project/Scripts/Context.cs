using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Context : MonoBehaviour
{
    private void Awake()
    {
        Config.ReadConfigFiles();
        Debug.Log(Config.playerConfig.turnSpeed);

        LocalPlayerData.instance = new LocalPlayerData();

        if (LocalPlayerData.instance.localData == null)
        {
            LocalPlayerData.instance.localData = new PlayerData();
            LocalPlayerData.SaveData(LocalPlayerData.instance.localData);
        }
    }

    private void Start()
    {
        
    }
}