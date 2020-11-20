using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Video;

public class SongPanel : MonoBehaviour
{
    public Text SongName;
    public Text Artist;
    public Text BPM;
    public Image bg;

    public delegate void SongItemDisplayDelegate(SongName item);
    public event SongItemDisplayDelegate onClick;

    public SongName item;

    public AudioClip music;
    public TextAsset sheet;
    public VideoClip BGA;
    public VideoPlayer videoPlayer;

    static int Clicks = 0;
    static GameObject Selected = null;

    public void Start()
    {
        if (item != null)
        {
            Prime(item);
        }
        videoPlayer.SetDirectAudioVolume(0, 0.1f);
    }

    public void Prime(SongName item)
    {
        this.item = item;
    }
    public void Click()
    {
        if(onClick != null)
        {
            onClick.Invoke(item);
        }
        else
        {
            if (bg != null)
                bg.sprite = item.BG;
            if (SongName != null)
                SongName.text = item.songName;
            if(Artist != null)
                Artist.text = item.Artist;
            if (BPM != null)
                BPM.text = item.BPM;
            SongInfo.Instance.SetInfo(music, sheet, BGA, item.BG);
            Clicks++;
            if (Clicks.Equals(1))
            {
                if (Selected != null)
                    Selected.GetComponent<Button>().interactable = true;
                GetComponent<Button>().interactable = false;
                Clicks = 0;
                Selected = gameObject;
            }
        }
    }
}