using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    public AudioSource hit;
    public AudioSource comboBreak;

    void Awake() {
        instance = this;
    }
    public static SoundManager Instance {
        get {
            return instance;
        }
    }

    public void HitSoundPlay() {
        hit.Play();
    }
    public void ComboBreakSoundPlay() {
        comboBreak.Play();
    }
}
