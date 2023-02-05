using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatTrigger : AbstractTriggerable
{
    public PlayerStats statToModifiy;
    public Items itemType; 

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
        string templateId = GameConstants.GetItemStringBasedOnType(itemType);
        if (Config.itemConfig.items[templateId].damaging)
        {
            PlayerService.DecreaseStat(statToModifiy, Config.itemConfig.items[templateId].statEffect);
        }
        else
        {
            PlayerService.IncreaseStat(statToModifiy, Config.itemConfig.items[templateId].statEffect);
        }

        SoundManager.instance.PlayItemSound(itemType);
        Destroy(gameObject);
    }
}
