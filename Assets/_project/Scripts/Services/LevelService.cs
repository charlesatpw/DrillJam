using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LayerLevel
{
    Start,
    Middle,
    End
}

public class LevelService
{
    public static LayerLevel GetCurrentLayerLevel(int metersToCompare)
    {
        int currentLevel = 0;
        foreach (int min in Config.rootConfig.minForNextLayer)
        {
            if (metersToCompare > min)
            {
                currentLevel++;
            }
        }

        return (LayerLevel)currentLevel;
    }
}
