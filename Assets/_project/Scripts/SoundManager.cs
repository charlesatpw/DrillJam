using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundManager;

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
        ItemPickup_RadioactiveBarrel
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

    private static Dictionary<SoundClip, AudioClip> sounds= new Dictionary<SoundClip, AudioClip>();
    [SerializeField]
    private List<AudioClip> soundClips = new List<AudioClip>(); 

    private void OnValidate()
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
    }

    private void OnEnable()
    {
        RootUI.instance.playerDeath += PlayDeathSound;
        RootUI.instance.playerWin += PlayWinSound;
    }

    private void OnDisable()
    {
        RootUI.instance.playerDeath -= PlayDeathSound;
        RootUI.instance.playerWin -= PlayWinSound;
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
        sfxSource.Stop();
        musicSource.Stop();
        voiceLineSource.Stop();
    }

    void PlayDeathSound()
    {
        PlayClip(SoundClip.DeathJingle);
    }

    void PlayWinSound()
    {
        PlayClip(SoundClip.WinJingle);
    }
}
