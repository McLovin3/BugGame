using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager current;

    [Header("UI sfx and background music")]
    public AudioSource backgroundMusic;
    public AudioSource btnEnterSfx;
    public AudioSource btnSelectSfx;
    public AudioSource closeMenuSfx;
    public AudioSource applySfx;

    private void Awake()
    {
        current = this;
    }

    public void PlaySFX(AudioSource targetSfx)
    {
        targetSfx.Play();
    }

    public void PlayMusic(AudioSource targetMusic)
    {
        targetMusic.Play();
        targetMusic.loop = true;
    }
}
