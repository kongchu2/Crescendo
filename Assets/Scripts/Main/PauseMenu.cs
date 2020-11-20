using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPause = false;
    public static void PauseAndResume(bool pause)
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
    public void _PauseAndResume(bool pause)
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
