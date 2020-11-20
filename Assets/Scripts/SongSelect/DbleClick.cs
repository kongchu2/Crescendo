using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DbleClick : MonoBehaviour , IPointerClickHandler
{
    public AudioSource sound;
    public GameObject Selected = null;
    
    public void Start()
    {
      sound = GetComponent<AudioSource>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.clickCount == 2)
        {
            GameObject.Find("Fade").GetComponent<Fade2>().FadeIn();
            sound.Play();
            FindObjectOfType<SceneChange>().Delay();
        }
    }

}
