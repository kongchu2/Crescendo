using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
public class Fade2 : MonoBehaviour
{

    public Image fadeImage;
    public VideoPlayer videoPlayer;

    public float fadeDelay = 3.0f;  //화면전환시간

    public float alphaValue = 0.01f;    //알파값

    private float currentTime = 0.0f;   //현재시간

    public float currentTime2 = 0.0f;


    private bool isTransition = false;  //화면을 전환시키는지 여부 


    private void OnEnable()
    {
        currentTime2 = Time.time;
    }
    void Update()
    {
        if (isTransition)
        {
            if (Time.time < currentTime + fadeDelay)
            {
                videoPlayer.SetDirectAudioVolume(0, videoPlayer.GetDirectAudioVolume(0) - Time.deltaTime * 0.1f);
                fadeImage.color += new Color(0, 0, 0, Time.deltaTime / fadeDelay);
            }
            else
            {
                videoPlayer.SetDirectAudioVolume(0, 0);
                isTransition = false;
                fadeImage.color = new Color(0, 0, 0, 0f);
            }
        }
        else
        {
            if (Time.time < currentTime2 + fadeDelay)
            {
                fadeImage.color -= new Color(0, 0, 0, Time.deltaTime / fadeDelay);
            }

        }
    }

    public void FadeIn()
    {
        currentTime = Time.time;
        isTransition = true;
    }

}
