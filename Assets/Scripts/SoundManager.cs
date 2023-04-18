using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header("Sources")]
    [SerializeField] AudioSource sourceMusic;
    [SerializeField] AudioSource sourceFX;
    [SerializeField] AudioSource sourcePlayerFX;
    [Header("Clips")]
    [SerializeField] AudioClip soundShot;
    [SerializeField] AudioClip soundPlayerHit;
    [SerializeField] AudioClip soundEnemyHit;
    [SerializeField] AudioClip soundEnemyDeath;
    [SerializeField] AudioClip soundMenu;
    [SerializeField] AudioClip musicGameplay;
    [SerializeField] AudioClip musicTitle;

    float fadeDuration = .7f;
        
    void Start()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SetMusicVolume(float value)
    {
        sourceMusic.volume = value;
    }

    public void SetFXVolume(float value)
    {
        sourceFX.volume = value;
        sourcePlayerFX.volume = value;
    }

    public void PlayMenuSound()
    {
        sourcePlayerFX.clip = soundMenu;
        sourcePlayerFX.Play();
    }    
    
    public void PlayShotSound()
    {
        sourcePlayerFX.clip = soundShot;
        sourcePlayerFX.Play();
    }

    public void PlayPlayerHitSound()
    {
        sourcePlayerFX.clip = soundPlayerHit;
        sourcePlayerFX.Play();
    }

    public void PlayEnemyHitSound()
    {
        sourceFX.clip = soundEnemyHit;
        sourceFX.Play();
    }

    public void PlayEnemyDeathSound()
    {
        sourceFX.clip = soundEnemyDeath;
        sourceFX.Play();
    }

    public void PlayGameplayMusic()
    {
        StartCoroutine(ChangeMusicWithFade(sourceMusic, musicGameplay, fadeDuration));
    }

    public void PlayTitleMusic()
    {
        StartCoroutine(ChangeMusicWithFade(sourceMusic, musicTitle, fadeDuration));
    }

    private static IEnumerator ChangeMusicWithFade(AudioSource source, AudioClip clip, float fadeTime)
    {
        float volumeInit = source.volume;
        while (source.volume > 0.01f)
        {
            source.volume -= 0.5f * Time.deltaTime / fadeTime;
            yield return null;
        }
        source.Stop();
        source.clip = clip;
        source.Play();

        while (source.volume < volumeInit)
        {
            source.volume += 0.5f * Time.deltaTime / fadeTime;
            yield return null;
        }


    }
}
