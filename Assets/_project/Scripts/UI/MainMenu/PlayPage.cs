using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayPage : MainPage
{
    [SerializeField]
    Button playGameButton;

    [SerializeField]
    Scene loadingScene;

    public override void Init(MainMenuUI mainMenu)
    {
        base.Init(mainMenu);

        playGameButton.onClick.RemoveAllListeners();
        playGameButton.onClick.AddListener(PlayGame);
    }

    private void PlayGame()
    {
        SceneManager.LoadScene(loadingScene.name);    
    }
}
