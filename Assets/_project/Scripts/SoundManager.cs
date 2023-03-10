using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

#if UNITY_EDITOR
    [SerializeField]
    [Tooltip("For Visual Purposes in editor only")]
    private SoundClip clip;
#endif

    public enum SoundClip
    {
        None,
        Button_Click,
        MenuMusic,
        GameMusic,
        Drill,
        ItemPickup_Fert,
        ItemPickup_Water,
        RockHit,
        DeathJingle,
        BeatPBNoise,
        WinJingle,
        EnemyHit,
        ItemPickup_RadioactiveBarrel,
        ItemPickup_JerryCan
    }

    public enum VoiceLines
    {
        None,

    }

    [SerializeField]
    private AudioSource sfxSource;

    [SerializeField]
    private AudioSource musicSource;

    [SerializeField]
    private AudioSource voiceLineSource;

    public AudioSource loopSource;

    private static Dictionary<SoundClip, AudioClip> sounds= new Dictionary<SoundClip, AudioClip>();
    [SerializeField]
    private List<AudioClip> soundClips = new List<AudioClip>(); 

    private void OnValidate()
    {
        SetDictionary();
    }

    private void SetDictionary()
    {
        for (int i = 0; i < soundClips.Count; ++i)
        {
            if (sounds.TryGetValue((SoundClip)i, out AudioClip soundClip))
            {
                if (soundClip != soundClips[i])
                {
                    sounds[(SoundClip)i] = soundClip;
                }
            }
            else
            {
                sounds.Add((SoundClip)i, soundClips[i]);
            }
        }
    }

    private void Awake()
    {
        if (instance)
        {
            Destroy(this);
            return;
        }

        instance = this;
        SetDictionary();
    }

    private void OnEnable()
    {
        _ = SubscribePlayerEvents();
    }

    private void OnDisable()
    {
        if (RootUI.instance)
        {
            RootUI.instance.playerDeath -= PlayDeathSound;
            RootUI.instance.playerWin -= PlayWinSound;
        }
    }

    public void PlayClipWithSource(SoundClip soundClip, AudioSource source)
    {
        if (sounds.TryGetValue(soundClip, out AudioClip clipToPlay) && sfxSource)
        {
            source.clip = clipToPlay;
            source.Play();
        }
    }

    public void PlayClip(SoundClip soundClip)
    {
        if (sounds.TryGetValue(soundClip, out AudioClip clipToPlay) && sfxSource)
        {
            sfxSource.clip = clipToPlay;

            sfxSource.pitch = 1 + Random.Range(-0.05f, 0.05f);
            sfxSource.Play();
        }
    }

    public void PlayTrack(SoundClip musicClip)
    {
        if (sounds.TryGetValue(musicClip, out AudioClip clipToPlay) && musicSource)
        {
            musicSource.clip = clipToPlay;
            musicSource.Play();
        }
    }

    public void PlayVoiceLine(SoundClip musicClip)
    {
        if (sounds.TryGetValue(musicClip, out AudioClip clipToPlay) && voiceLineSource)
        {
            voiceLineSource.clip = clipToPlay;
            voiceLineSource.Play();
        }
    }

    public void StopAllSounds()
    {
        if (sfxSource.isPlaying)
        {
            sfxSource.Stop();
        }

        if (musicSource.isPlaying)
        {
            musicSource.Stop();
        }

        if (voiceLineSource.isPlaying)
        {
            voiceLineSource.Stop();
        }

        if (loopSource.isPlaying)
        {
            loopSource.Stop();
        }
    }

    void PlayDeathSound()
    {
        StopAllSounds();
        PlayClip(SoundClip.DeathJingle);
    }

    void PlayWinSound()
    {
        StopAllSounds();
        PlayClip(SoundClip.WinJingle);
    }

    async UniTask SubscribePlayerEvents()
    {
        await UniTask.WaitUntil(() => RootUI.instance != null);
        RootUI.instance.playerDeath += PlayDeathSound;
        RootUI.instance.playerWin += PlayWinSound;
    }

    public void PlayItemSound(Items itemType)
    {
        switch (itemType) 
        {
            case Items.Item_Jerry_Can:
                PlayClip(SoundClip.ItemPickup_JerryCan);
                break;
            case Items.Item_Rock:
                PlayClip(SoundClip.RockHit);
                break;
            case Items.Item_Fertilizer:
                PlayClip(SoundClip.ItemPickup_Fert);
                break;
            case Items.Item_Water_Pocket:
                PlayClip(SoundClip.ItemPickup_Water);
                break;
            case Items.Item_Radiation_Barrel:
                PlayClip(SoundClip.ItemPickup_RadioactiveBarrel);
                break;
        }
    }
}
