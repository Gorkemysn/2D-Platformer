using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSoundManager : MonoBehaviour
{
    public AudioSource source;

    public AudioClip clickSound;

    public void PlayClickSound()
    {
        source.clip = clickSound;
        source.Play();
    }
}
