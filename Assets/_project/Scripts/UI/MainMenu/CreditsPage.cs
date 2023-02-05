using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CreditsPage : MainPage
{
    [SerializeField]
    ScrollRect creditsRect;

    Coroutine scrollRoutine;

    public override void Init(MainMenuUI mainMenu)
    {
        base.Init(mainMenu);
        scrollRoutine = StartCoroutine(CreditsScroll());
    }

    public override void OnClose()
    {
        base.OnClose();
        StopCoroutine(scrollRoutine);
        creditsRect.normalizedPosition = new Vector2(0, 1);
    }

    IEnumerator CreditsScroll()
    {
        creditsRect.normalizedPosition = new Vector2(0, 1);

        for (float t = 0; t < 10; t += Time.deltaTime)
        {
            creditsRect.normalizedPosition = new Vector2(0, 1 - (t / 10));
            yield return null;
        }
    }
}
