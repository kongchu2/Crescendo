using UnityEngine;
using UnityEngine.Video;

public class BGAPlayer : MonoBehaviour
{
    public static VideoPlayer BGA;

    private void Start()
    {
        BGA = GetComponent<VideoPlayer>();
        BGA.clip = SongInfo.Instance.getBGA();
        Invoke("BGASetActive", 1f);
    }
    private void BGASetActive()
    {
        BGA.Play();
        
    }
}
