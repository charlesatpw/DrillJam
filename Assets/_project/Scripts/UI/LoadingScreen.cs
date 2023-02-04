using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

class LoadingBuffer
{
    public static LoadingBuffer instance;
    public string sceneToLoad;

    public LoadingBuffer() 
    {
        instance = this;
    }
}

public class LoadingScreen : MonoBehaviour
{
    string defaultSceneToLoad = GameConstants.MenuScene;

    [SerializeField]
    Animator drillAnimator;
    [SerializeField]
    List<ParticleSystem> digParticleEffects = new List<ParticleSystem>();

    [SerializeField]
    private Context context;

    private void Awake()
    {
        if (LoadingBuffer.instance == null)
        {
            LoadingBuffer.instance = new LoadingBuffer();
            LoadingBuffer.instance.sceneToLoad = defaultSceneToLoad;
        }

        foreach (ParticleSystem effect in digParticleEffects)
        {
            if (effect)
            {
                effect.Play();
            }
        }

        _ = SpeedUpDrill();
        _ = LoadSceneAsync();
    }

    async UniTask LoadSceneAsync()
    {
        await UniTask.WaitUntil(() => context.initialised);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(LoadingBuffer.instance.sceneToLoad);
        await UniTask.WaitUntil(() => asyncLoad.isDone);
    }

    async UniTaskVoid SpeedUpDrill()
    {
        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            if (drillAnimator)
            {
                drillAnimator.speed = t;
            }
            await UniTask.Yield();
        }
    }
}
