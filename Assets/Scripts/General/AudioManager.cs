using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource sfxAudioSource, musicAudioSource, damageAudioSource;

    public static AudioManager InstanceAudio { get; private set; }

    private void Awake()
    {
        if(InstanceAudio != null && InstanceAudio != this)
        {
            Destroy(this);
        }
        else
        {
            InstanceAudio = this;
            DontDestroyOnLoad(this);
        }
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
