using Cinemachine;
using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public bool gameOver = false;

    [SerializeField]
    PlayerManager playerManager;

    [SerializeField]
    CinemachineVirtualCamera cutsceneAscendCamera;

    public void Init()
    {

    }

    public async UniTask RunCutscene()
    {
        gameOver = true;

        playerManager.DisablePlayer();
        RootUI.instance.GetMainGameUI()?.ShowWinScreen();
    }
}