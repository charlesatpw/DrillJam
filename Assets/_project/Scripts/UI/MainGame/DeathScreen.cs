using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathScreen : MonoBehaviour
{
    [SerializeField]
    Button menuButton;

    [SerializeField]
    Button retryButton;

    public void Init()
    {
        menuButton.onClick.RemoveAllListeners();
        menuButton.onClick.AddListener(GoToMenu);

        retryButton.onClick.RemoveAllListeners();
        retryButton.onClick.AddListener(ResetLevel);
    }

    private void GoToMenu()
    {
        menuButton.interactable = false;
        retryButton.interactable = false;

        LoadingBuffer.instance = null;
        SceneManager.LoadScene(GameConstants.LoadingScene);
    }

    private void ResetLevel()
    {
        menuButton.interactable = false;
        retryButton.interactable = false;

        LoadingBuffer.instance = new LoadingBuffer();
        LoadingBuffer.instance.sceneToLoad = GameConstants.GameScene;
        SceneManager.LoadScene(GameConstants.LoadingScene);
    }
}
