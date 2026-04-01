using UnityEngine;
using UnityEngine.Audio;
[System.Serializable]
public class Sound
{
    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;
    public string name;
    public bool loop;

    [HideInInspector]
    public AudioSource source;

    //FindObjectOfType<AudioManager>().Play("name of sound");
    //place where you want the sound to play
    

}
