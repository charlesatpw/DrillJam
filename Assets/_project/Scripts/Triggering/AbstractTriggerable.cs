using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractTriggerable : MonoBehaviour, ITriggerable
{
    public Action playerHitAction;

    public Action GetPlayerHitAction()
    {
        return playerHitAction;
    }
}
