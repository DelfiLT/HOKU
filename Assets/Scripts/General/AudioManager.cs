using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource sfxAudioSource, musicAudioSource, damageAudioSource;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider musicSlider;
    private float musicFloat;
    private string musicPref;
    private float sfxfloat;
    private string sfxPref;

    public static AudioManager InstanceAudio { get; private set; }

    private void Awake()
    {
        if(InstanceAudio == null)
        {
            InstanceAudio = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayMusic(AudioClip clip)
    {
        musicAudioSource.Stop();
        musicAudioSource.PlayOneShot(clip);
    }

    public void PlaySound(AudioClip clip)
    {
        sfxAudioSource.PlayOneShot(clip);
    }

    public void PlayDamageSound(AudioClip clip)
    {
        damageAudioSource.PlayOneShot(clip);
    }
}
