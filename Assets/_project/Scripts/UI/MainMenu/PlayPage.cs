using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayPage : MainPage
{
    [SerializeField]
    Button playGameButton;

    [SerializeField]
    TextMeshProUGUI highscoreText;
    [SerializeField]
    Image highscoreImage;

    [SerializeField]
    List<Sprite> highscoreSprites= new List<Sprite>();

    public override void Init(MainMenuUI mainMenu)
    {
        base.Init(mainMenu);

        playGameButton.onClick.RemoveAllListeners();
        playGameButton.onClick.AddListener(PlayGame);

        highscoreText.text = "Dig Highscore: " + LocalPlayerData.instance.localData.highestMScore.ToString();
        highscoreImage.sprite = highscoreSprites[(int)LevelService.GetCurrentLayerLevel(LocalPlayerData.instance.localData.highestMScore)];
    }

    private void PlayGame()
    {
        LoadingBuffer.instance = new LoadingBuffer();
        LoadingBuffer.instance.sceneToLoad = GameConstants.GameScene;
        SceneManager.LoadScene(GameConstants.LoadingScene);    
    }
}
