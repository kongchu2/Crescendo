using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MusicManager : MonoBehaviour
{
    private AudioSource music;

    public GameObject BGA;

    public static float currentMusicTime;
    private double trackStartTime;

    public static Dictionary<string, string> musicInfo = new Dictionary<string, string>();

    private void Awake()
    {
        music = GetComponent<AudioSource>();
        music.clip = SongInfo.Instance.getMusic();
        BGA.GetComponent<VideoPlayer>().clip = SongInfo.Instance.getBGA();
        Invoke("BGAStartTime", 1f);
    }
    private void Start()
    {
        trackStartTime = AudioSettings.dspTime + 1;
        music.PlayScheduled(trackStartTime);

    }

    private void BGAStartTime()
    {
        BGA.SetActive(true);
    }
    private void Update()
    {
        currentMusicTime = (float)(AudioSettings.dspTime - trackStartTime);
    }
}
