using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonParser
{
    public static string jsonPath = Application.streamingAssetsPath + "/configs/";

    public static object ReadFile<Type>(string type)
    {
        try
        {
            string path = jsonPath + type.ToLower() + ".json";
            string jsonInput = string.Empty; 

            if (File.Exists(path))
            {
                StreamReader reader = new StreamReader(path, true);
                jsonInput = reader.ReadToEnd();
            }
            else
            {
                Debug.LogError("no config at " + path);
                return null;
            }

            return JsonConvert.DeserializeObject<Type>(jsonInput);
        }
        catch
        {
            Debug.LogError("couldn't parse json file " + type.ToString());
            return null;
        }
    }
}
