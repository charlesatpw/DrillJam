using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayPage : MainPage
{
    [SerializeField]
    Button playGameButton;

    public override void Init(MainMenuUI mainMenu)
    {
        base.Init(mainMenu);

        playGameButton.onClick.RemoveAllListeners();
        playGameButton.onClick.AddListener(PlayGame);
    }

    private void PlayGame()
    {
        LoadingBuffer.instance = new LoadingBuffer();
        LoadingBuffer.instance.sceneToLoad = GameConstants.GameScene;
        SceneManager.LoadScene(GameConstants.LoadingScene);    
    }
}
