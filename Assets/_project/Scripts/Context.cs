using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Context : MonoBehaviour
{
    public bool initialised = false;

    private void Awake()
    {
        LocalPlayerData.instance = new LocalPlayerData();

        if (Config.FilesRead() && LocalPlayerData.instance.localData != null)
        {
            initialised = true;
            return;
        }

        Config.ReadConfigFiles();

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