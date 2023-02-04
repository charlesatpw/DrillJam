using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatTrigger : AbstractTriggerable
{
    public PlayerStats statToModifiy;

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
        PlayerService.IncreaseStat(statToModifiy, 1);
        Destroy(gameObject);
    }
}
