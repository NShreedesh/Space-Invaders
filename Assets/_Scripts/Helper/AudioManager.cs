using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioSource enemyMovementSourceEffect;

    [SerializeField] private AudioSource shootEffectSource;
    [SerializeField] private AudioSource enemyDeadEffectSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    public void Play_PlayerShootAudio(AudioClip audioClip)
    {
        shootEffectSource.PlayOneShot(audioClip);
    }

    public void Play_EnemyDeadAudio(AudioClip audioClip)
    {
        enemyDeadEffectSource.PlayOneShot(audioClip);
    }

    public void Play_EnemyMovementAudio(AudioClip audioClip)
    {
        enemyDeadEffectSource.PlayOneShot(audioClip);
    }
}
