using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewSong : MonoBehaviour
{
    public AudioSource music;
    public AudioClip clip;

    public int previewTime = 10;

    public void Start()
    {
        music = GetComponent<AudioSource>();
    }       
    public void PreviewAudio(string SongName)
    {
        clip = Resources.Load(SongName+"/"+SongName) as AudioClip;
        music.clip = clip;


        music.timeSamples = 0;
        music.timeSamples += music.clip.frequency * previewTime;

        music.Play();
    }
}
