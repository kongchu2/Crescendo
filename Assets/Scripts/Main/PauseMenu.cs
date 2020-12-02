using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private static PauseMenu instance = null;
    void Awake() {
        instance = this;
    }
    public static PauseMenu Instance {
        get {
            return instance;
        }
    }

    public bool isPause = false;
    public void PauseAndResume(bool pause)
    {
        if(Time.time <= 1)
            return;

        UIManager.Instance.setPauseUI(pause);
        isPause = pause;
        AudioListener.pause = pause;
        if(pause) {
            BGAPlayer.BGA.Pause();
            Time.timeScale = 0f;
        }
        else {
            BGAPlayer.BGA.Play();
            Time.timeScale = 1f;
        }
    }
}
