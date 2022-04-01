using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

class AudioManager : MonoBehaviour, IAudioManager
{
    [SerializeField] private List<AudioClip> clips;
    [SerializeField] private AudioSource audioSource;
    public void Play(string nameOfAudio)
    {
        audioSource.PlayOneShot(GetAudioClip(nameOfAudio));
    }

    public AudioClip GetAudioClip(string nameOfAudio)
    {
        foreach (var clip in clips.Where(clip => clip.name == nameOfAudio))
        {
            return clip;
        }
        throw new Exception($"Audio clip with name {nameOfAudio} not found");
    }
}