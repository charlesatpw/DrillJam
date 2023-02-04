using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class LocalPlayerData
{
    public static LocalPlayerData instance;
    public static string fullFilePath;

    public PlayerData localData;

    public LocalPlayerData()
    {
        fullFilePath = Application.persistentDataPath + Path.DirectorySeparatorChar + Config.playerDataFileName;
        localData = LoadData();
        instance = this;
    }

    public static void SaveData(PlayerData player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(fullFilePath, FileMode.Create);
        PlayerData charData = new PlayerData(player);

        formatter.Serialize(stream, charData);
        stream.Close();
    }

    public static void SaveData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(fullFilePath, FileMode.Create);
        PlayerData charData = new PlayerData(instance.localData);

        formatter.Serialize(stream, charData);
        stream.Close();
    }

    public static PlayerData LoadData()
    {
        if (File.Exists(fullFilePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(fullFilePath, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;

            stream.Close();

            return data;
        }
        else
        {
#if UNITY_EDITOR
            Debug.LogError("Error: Save file not found in " + fullFilePath);
            Debug.Log("Creating new player save");
#endif
            return null;
        }
    }
}
