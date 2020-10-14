using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public AudioSource Bgm;
    public GameObject Mainmenu;
    public GameObject SongSelect;

    public Image fadeImage;
    
    public float fadeDelay = 3.0f;  //화면전환시간

    public float alphaValue = 0.01f;    //알파값

    public float currentTime = 0.0f;   //현재시간

    public bool isTransition = false;  //화면을 전환시키는지 여부 

    void Update()

    {
        if (isTransition)
        {
            if(Time.time < currentTime + fadeDelay)
            {
                Bgm.volume -= Time.deltaTime * 0.1f;
                fadeImage.color += new Color(0, 0, 0, Time.deltaTime / fadeDelay);
            }
            else
            {
                Bgm.volume = 0f;
                isTransition = false;
                fadeImage.color = new Color(0, 0, 0, 0f);
                SongSelect.SetActive(true);
                Mainmenu.SetActive(false);
            }
        }
    }

    public void FadeIn()
    {
        currentTime = Time.time;
        isTransition = true;
    }

}
