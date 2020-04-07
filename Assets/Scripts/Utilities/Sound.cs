using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public AudioClip clip;
    public string name;
    public AudioSource source;
    public bool awakePlay;
    public bool loop;

    [Range(0f, 1f)]
    public float volume;
}
