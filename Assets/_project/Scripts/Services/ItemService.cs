using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemService
{
    public static float GetTotalItemWeight()
    {
        float total = 0f;
        foreach(ItemTemplate item in Config.itemConfig.items.Values)
        {
            total += item.weight;
        }
        return total;
    }
}