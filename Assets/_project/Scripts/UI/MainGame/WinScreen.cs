using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    [SerializeField]
    Button menuButton;

    public void Init()
    {
        menuButton.onClick.RemoveAllListeners();
        menuButton.onClick.AddListener(GoToMenu);
    }

    private void GoToMenu()
    {
        menuButton.interactable = false;
        LoadingBuffer.instance = null;
        SceneManager.LoadScene(GameConstants.LoadingScene);
    }
}
