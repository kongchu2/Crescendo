using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource music;

    public static float currentMusicTime;
    private double trackStartTime;

    public static Dictionary<string, string> musicInfo = new Dictionary<string, string>();

    private void Awake()
    {
        music = GetComponent<AudioSource>();
        music.clip = SongInfo.Instance.getMusic();
        Invoke("MusicFinished", music.clip.length);
    }
    private void Start()
    {
        trackStartTime = AudioSettings.dspTime + 1;//AudioSettings.dspTime: 오디오 시스템의 현재 시간
        music.PlayScheduled(trackStartTime); //PlayScheduled(): AudioSettings.dspTime이 사운드 재생을 시작할 때 참조하는 절대 타임 라인의 시간 (초)입니다.
    }
    private void MusicFinished() {
        GameManager.ChangeScene("Result");
    }
    private void Update() {
        currentMusicTime = (float)(AudioSettings.dspTime - trackStartTime);
    }
}