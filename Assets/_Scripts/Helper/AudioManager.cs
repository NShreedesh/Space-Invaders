using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Enemy Audio Source Info")]
    [SerializeField] private AudioSource enemyMovementSourceEffect;
    [SerializeField] private AudioSource enemyDeadEffectSource;
    [SerializeField] private AudioSource enemyShootEffectSource;

    [Header("Player Audio Source Info")]
    [SerializeField] private AudioSource playerShootEffectSource;
    [SerializeField] private AudioSource playerDeadEffectSource;

    [Header("Boss Audio Source Info")]
    [SerializeField] private AudioSource redInvaderSpawnEffectSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void Play_PlayerShootAudio(AudioClip audioClip)
    {
        if (audioClip == null) return;

        playerShootEffectSource.PlayOneShot(audioClip);
    }

    public void Play_EnemyDeadAudio(AudioClip audioClip)
    {
        enemyDeadEffectSource.PlayOneShot(audioClip);
    }

    public void Play_PlayerDeadAudio(AudioClip audioClip)
    {
        playerDeadEffectSource.PlayOneShot(audioClip);
    }

    public void Play_EnemyMovementAudio(AudioClip audioClip)
    {
        enemyMovementSourceEffect.PlayOneShot(audioClip);
    }


    public void Play_EnemyShootAudio(AudioClip audioClip)
    {
        enemyShootEffectSource.PlayOneShot(audioClip);
    }

    public void Play_RedInvaderSpawnEffectAudio(AudioClip audioClip)
    {
        redInvaderSpawnEffectSource.clip = audioClip;
        redInvaderSpawnEffectSource.Play();
    }

    public void Stop_RedInvaderSpawnEffectAudio()
    {
        if(redInvaderSpawnEffectSource == null) return;
        redInvaderSpawnEffectSource.Stop();
    }
}
