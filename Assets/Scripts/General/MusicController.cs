using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private bool musicPlaying;
    [SerializeField] private AudioClip music;
    void Start()
    {
        AudioManager.InstanceAudio.PlayMusic(music);
    }
}
