using UnityEngine;

interface IAudioManager
{
    void Play(string nameOfAudio);
    AudioClip GetAudioClip(string nameOfAudio);
}