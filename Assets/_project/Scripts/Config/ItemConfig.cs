using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemConfig
{
    public int maxTriesPerSpawn { get; set; }
    public int numOfItemsPerSection { get; set; }
    public int itemSectionCount { get; set; }
    public Dictionary<string, ItemTemplate> items = new Dictionary<string, ItemTemplate>();

    public ItemConfig() { }
}
