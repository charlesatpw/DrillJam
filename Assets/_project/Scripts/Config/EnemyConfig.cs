using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConfig
{
    public Dictionary<string, EnemyTemplate> enemies = new Dictionary<string, EnemyTemplate>();
    public Dictionary<string, EnemyWeaponTemplate> enemyweapons = new Dictionary<string, EnemyWeaponTemplate>();
    public Dictionary<string, EnemyGroupTemplate> enemyGroups = new Dictionary<string, EnemyGroupTemplate>();

    public EnemyConfig()
    {

    }
}
