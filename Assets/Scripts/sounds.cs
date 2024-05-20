using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;
using System;

[System.Serializable]
public class sounds 
{
    // Start is called before the first frame update
    public string name;
    public AudioClip clip;
    [Range(0f,2f)]
    public float volume;
    [Range(0.1f,3f)]
    public float pitch;
    [HideInInspector]
    public AudioSource source;
    public bool loop;
    [Range(0f,1f)]
    public float spatialBlend;
}
