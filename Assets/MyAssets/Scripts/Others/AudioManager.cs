using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/AudioManager")]
public class AudioManager : ScriptableObject
{
    public AudioSource Audio { get; set; }
    public float Volume { get; set; }

    public void SetVolume(float volume)
    {
        Volume = volume;
    }

    public void PlayOneShot(AudioClip clip)
    {
        if (!Audio)
        {
            return;
        }

        Audio.PlayOneShot(clip, Volume);
    }

    public void PlayOneShot(AudioClip clip, float volume)
    {
        if (!Audio)
        {
            return;
        }

        Audio.PlayOneShot(clip, volume);
    }
}
