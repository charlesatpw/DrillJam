using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTemplate
{
    public float weight { get; set; }
    public int minSpawnDepth { get; set; }
    public int statEffect { get; set; }
    public bool damaging { get; set; }

    public ItemTemplate() { }
}
