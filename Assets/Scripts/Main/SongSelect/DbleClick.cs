﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DbleClick : MonoBehaviour , IPointerClickHandler
{
    public AudioSource sound;
    
    public void Start()
    {
      sound = GetComponent<AudioSource>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.clickCount == 2)
        {
            GameObject.Find("Fade").GetComponent<Fader>().FadeIn();
            sound.Play();
            FindObjectOfType<SceneChange>().Delay();
        }
    }
}
