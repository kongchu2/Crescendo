using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;
public class Fader : MonoBehaviour
{

    public Image fadeImage;
    public AudioSource Preview;

    public float fadeDelay = 3.0f;  //화면전환시간

    public float alphaValue = 0.01f;    //알파값

    private float currentTime = 0.0f;   //현재시간

    private bool isTransition = false;  //화면을 전환시키는지 여부 

    void Update()
    {
        if (isTransition)
        {
            if (Time.time < currentTime + fadeDelay)
            {
                Preview.volume -= Time.deltaTime * 0.1f;
                fadeImage.color += new Color(0, 0, 0, Time.deltaTime / fadeDelay);
            }
            else
            {
                Preview.volume = 0f;
                isTransition = false;
                fadeImage.color = new Color(0, 0, 0, 0f);
            }
        }
    }

    public void FadeIn()
    {
        currentTime = Time.time;
        isTransition = true;
    }

}
