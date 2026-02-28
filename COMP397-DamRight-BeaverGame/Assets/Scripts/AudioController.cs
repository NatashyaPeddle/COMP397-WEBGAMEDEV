//Natashya Peddle  301487275

using System.Collections;
using UnityEngine;

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

 

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);
        PlayBGMusic();


        MusicSlider.value = musicSource.volume;
        SFXSlider.value = sfxSource.volume;


        MusicSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
        MusicSlider.onValueChanged.AddListener(OnSFXVolumeChanged);

    }

    private void OnMusicVolumeChanged(float value)
    {
        musicSource.volume = value;
    }

    private void OnSFXVolumeChanged(float value)
    {
        sfxSource.volume = value;
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
}
