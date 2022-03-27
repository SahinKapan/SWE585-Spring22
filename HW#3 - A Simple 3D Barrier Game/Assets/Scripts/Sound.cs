using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Sound class
[System.Serializable]
public class Sound 
{
    public string name;
    public AudioClip clip;

    public float volume;

    public bool loop;

    public AudioSource source;
}
