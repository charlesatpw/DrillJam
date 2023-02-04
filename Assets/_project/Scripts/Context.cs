using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Context : MonoBehaviour
{
    public bool initialised = false;

    private void Awake()
    {
        if (Config.FilesRead())
        {
            return;
        }

        Config.ReadConfigFiles();
        LocalPlayerData.instance = new LocalPlayerData();

        if (LocalPlayerData.instance.localData == null)
        {
            LocalPlayerData.instance.localData = new PlayerData();
            LocalPlayerData.SaveData(LocalPlayerData.instance.localData);
        }

        PlayerService playerService = new PlayerService();
        PlayerService.instance = playerService;

        initialised = true;
    }
}