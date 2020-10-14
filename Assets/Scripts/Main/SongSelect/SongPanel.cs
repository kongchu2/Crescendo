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
    public Image sprite;
    public Image bg;

    public delegate void SongItemDisplayDelegate(SongName item);
    public event SongItemDisplayDelegate onClick;

    public SongName item;
    public PreviewSong previewSong;

    public AudioClip music;
    public TextAsset sheet;
    public VideoClip BGA;

    static int Clicks = 0;
    static GameObject Selected = null;

    public void Start()
    {
        if (item != null)
        {
            Prime(item);
        }
        previewSong = GameObject.Find("Preview").GetComponent<PreviewSong>();
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
           
            previewSong.PreviewAudio(item.songName);
            if (sprite != null)
                sprite.sprite = item.SongImage;
            if (bg != null)
                bg.sprite = item.BG;
            if (SongName != null)
                SongName.text = item.songName;
            if(Artist != null)
                Artist.text = item.Artist;
            if (BPM != null)
                BPM.text = item.BPM;
            SongInfo.Instance.SetInfo(music, sheet, BGA);

            Clicks++;
            if (Clicks.Equals(1))
            {
                if(Selected != null)
                {
                    Selected.GetComponent<Button>().interactable = true;
                }
                GetComponent<Button>().interactable = false;
                Clicks = 0;
                Selected = gameObject;
            }
        }
    }
}