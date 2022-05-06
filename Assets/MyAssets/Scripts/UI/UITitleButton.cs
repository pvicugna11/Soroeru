using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITitleButton : UIButton
{
    public AudioManager Audio;
    public AudioClip Clip;
    public float ClipVolume;

    private void Start()
    {
        Audio.PlayOneShot(Clip, ClipVolume);
    }
}
