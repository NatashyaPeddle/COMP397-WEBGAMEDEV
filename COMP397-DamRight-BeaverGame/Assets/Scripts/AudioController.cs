///Code / Internal Documentation - File Name: AudioController
///Author's Name (s) & Student#: Natashya Peddle #301487275
///Program Description / Purpose: Acts as audio controller and manages all audio sources and clips. 

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private AudioClip jumpSFX;
    [SerializeField] private AudioClip deathSFX;
    [SerializeField] private AudioClip crunchSFX;
    [SerializeField] private AudioClip shootSFX;
    [SerializeField] private AudioClip playerHealSFX;
    [SerializeField] private AudioClip playerHurtSFX;
    [SerializeField] private AudioClip enemyHurtSFX;
    [SerializeField] private AudioClip enemyDefeatedSFX;
    
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    public Slider MusicSlider;
    public Slider SFXSlider;

    private const string MUSICVOLUME = "MusicVolume";
    private const string SFXVOLUME = "SFXVolume";



    private IEnumerator Start()
    {
        LoadVolumeSettings();

        yield return null;
        PlayBGMusic();

        if (MusicSlider != null)
        {
           MusicSlider.value = musicSource.volume; 
           MusicSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
        }

        if (SFXSlider != null)
        {
           SFXSlider.value = sfxSource.volume;
           SFXSlider.onValueChanged.AddListener(OnSFXVolumeChanged); 
        }

        SceneManager.sceneLoaded += OnSceneLoaded;

    }
    private void LoadVolumeSettings()
    {
        
        if (PlayerPrefs.HasKey(MUSICVOLUME))
        {
            musicSource.volume = PlayerPrefs.GetFloat(MUSICVOLUME, 1f);
        }
        else
        {
            musicSource.volume = 0.08f;
        }

        if (PlayerPrefs.HasKey(SFXVOLUME))
        {
            sfxSource.volume = PlayerPrefs.GetFloat(SFXVOLUME, 1f);
        }
        else
        {
            sfxSource.volume = 1f;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LoadVolumeSettings();
    }

    private void OnMusicVolumeChanged(float value)
    {
        
        musicSource.volume = value;

        PlayerPrefs.SetFloat(MUSICVOLUME, value);
    }

    private void OnSFXVolumeChanged(float value)
    {
        sfxSource.volume = value;

        PlayerPrefs.SetFloat(SFXVOLUME, value);
    }

    public void PlayJumpSFX()
    {
        PlaySFX(jumpSFX);
    }

    public void PlayDeathSFX()
    {
       PlaySFX(deathSFX);
    }

    public void PlayCrunchSFX()
    {
        PlaySFX(crunchSFX);
    }

    public void PlayShootSFX()
    {
        PlaySFX(shootSFX);
    }

    public void PlayPlayerHealSFX()
    {
        PlaySFX(playerHealSFX);
    }

    public void PlayPlayerHurtSFX()
    {
        PlaySFX(playerHurtSFX);
    }

    public void PlayEnemyHurtSFX()
    {
        PlaySFX(enemyHurtSFX);
    }
    public void PlayEnemyDefeatedSFX()
    {
        PlaySFX(enemyDefeatedSFX);
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip == null) return;
        sfxSource.PlayOneShot(clip);
    }

    public void PlayBGMusic()
    {

        musicSource.clip = backgroundMusic;
        musicSource.Play();

    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }


}
