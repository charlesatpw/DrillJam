using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : AbstractTriggerable
{
    public PlayerStats statToModifiy;
    public Enemy enemyType;

    private void OnEnable()
    {
        playerHitAction += OnPlayerHit;
    }

    private void OnDisable()
    {
        playerHitAction -= OnPlayerHit;
    }

    public void OnPlayerHit()
    {
        string templateId = GameConstants.GetEnemyStringBasedOnType(enemyType);
        PlayerService.DecreaseStat(statToModifiy, Config.enemyConfig.enemies[templateId].damage);
        Destroy(gameObject);
    }
}
