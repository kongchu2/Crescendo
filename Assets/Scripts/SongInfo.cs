using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class SongInfo
{
    private static SongInfo instance;

    private AudioClip music;
    private TextAsset sheet;
    private VideoClip BGA;

    public static SongInfo Instance {
        get {
            if(instance == null) {
                instance = new SongInfo();
            }
            return instance;
        }
    }
    private SongInfo(){}
    public void SetInfo(AudioClip _music, TextAsset _sheet, VideoClip _BGA) {
        this.music = _music;
        this.sheet = _sheet;
        this.BGA = _BGA;
        Print();
    }
    public AudioClip getMusic() {
        return music;
    }
    public TextAsset getSheet() {
        return sheet;
    }
    public VideoClip getBGA() {
        return BGA;
    }
    private void Print()
    {
        Debug.Log(this.music);
        Debug.Log(this.sheet);
        Debug.Log(this.BGA);
    }
    //private void Awake(){DontDestroyOnLoad(gameObject);}
}
