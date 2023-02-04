using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField]
    private Button playButton;

    [SerializeField]
    private Button optionsButton;

    [SerializeField]
    private Button creditsButton;

    [SerializeField]
    private Button quitButton;

    MainPageType openPage = MainPageType.None;
    public enum MainPageType
    {
        playPage,
        optionsPage,
        creditsPage,
        None
    }

    MainPage currentPage = null;
    [SerializeField]
    List<MainPage> pages = new List<MainPage>();

    public void Awake()
    {
        playButton.onClick.RemoveAllListeners();
        playButton.onClick.AddListener(() => OpenPage(MainPageType.playPage));

        optionsButton.onClick.RemoveAllListeners();
        optionsButton.onClick.AddListener(() => OpenPage(MainPageType.optionsPage));

        creditsButton.onClick.RemoveAllListeners();
        creditsButton.onClick.AddListener(() => OpenPage(MainPageType.creditsPage));

        quitButton.onClick.RemoveAllListeners();
        quitButton.onClick.AddListener(Quit);
    }

    public void OpenPage(MainPageType page)
    {
        if (currentPage != null)
        {
            currentPage.gameObject.SetActive(false);
        }

        openPage = page;

        if (page != MainPageType.None)
        {
            pages[(int)page].gameObject.SetActive(true);
            pages[(int)page].Init(this);
        }
    }

    public MainPage GetOpenPage()
    {
        if (openPage == MainPageType.None)
        {
            return null;
        }

        return pages[(int)openPage];
    }

    private void Quit()
    {
        Application.Quit();
    }
}
