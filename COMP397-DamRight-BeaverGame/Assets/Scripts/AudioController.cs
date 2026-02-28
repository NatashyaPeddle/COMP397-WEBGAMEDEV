//Natashya Peddle  301487275

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private AudioClip jumpSFX;
    [SerializeField] private AudioClip deathSFX;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    public Slider MusicSlider;
    public Slider SFXSlider;

    private const string MUSICVOLUME = "MusicVolume";
    private const string SFXVOLUME = "SFXVolume";



    private IEnumerator Start()
    {
        LoadVolumeSettings();

        yield return new WaitForSeconds(2f);
        PlayBGMusic();


        MusicSlider.value = musicSource.volume;
        SFXSlider.value = sfxSource.volume;


        MusicSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
        SFXSlider.onValueChanged.AddListener(OnSFXVolumeChanged);

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
            musicSource.volume = 1f;
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
        Debug.Log("Value changed to:" + value);

        MusicSlider.value = musicSource.volume;


        PlayerPrefs.SetFloat(MUSICVOLUME, value);
    }

    private void OnSFXVolumeChanged(float value)
    {
        sfxSource.volume = value;

        SFXSlider.value = sfxSource.volume;
        PlayerPrefs.SetFloat(SFXVOLUME, value);
    }

    public void PlayJumpSFX()
    {
        sfxSource.clip = jumpSFX;
        sfxSource.Play();


    }

    public void PlayDeathSFX()
    {
        sfxSource.clip = deathSFX;
        sfxSource.Play();


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
