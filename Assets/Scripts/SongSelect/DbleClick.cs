using UnityEngine;
using UnityEngine.EventSystems;

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
            SongInfo.Instance.setDifficulty(gameObject.name);
            sound.Play();
            FindObjectOfType<SceneChange>().Delay();
        }
    }
}
