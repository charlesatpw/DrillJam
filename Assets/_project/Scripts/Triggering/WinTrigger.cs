using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrigger : AbstractTriggerable
{
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
        RootUI.instance.CallPlayerWin();
    }
}
