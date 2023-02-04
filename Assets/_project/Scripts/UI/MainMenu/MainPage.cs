using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainPage : MonoBehaviour
{
    protected MainMenuUI mainMenu;

    [SerializeField]
    Button backButton;

    protected bool initialised = false;

    public virtual void Init(MainMenuUI mainMenu)
    {
        this.mainMenu = mainMenu;
        backButton.onClick.RemoveAllListeners();
        backButton.onClick.AddListener(() => mainMenu.OpenPage(MainMenuUI.MainPageType.None));
    }
}
