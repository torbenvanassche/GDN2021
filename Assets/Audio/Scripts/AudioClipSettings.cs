using UnityEngine;
using UnityEngine.Audio;

public class AudioClipSettings : ScriptableObject
{
    public AudioClip clip;
    public AudioMixerGroup mixerGroup;
    
    [Space, Range(0, 256)] public int priority = 128;
    [Range(0, 1)] public float volume = 1;
    [Range(0, 1)] public float pitch = 1;
    public bool loop = false;
}
