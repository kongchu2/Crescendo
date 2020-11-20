using UnityEngine;
using UnityEngine.Video;

public class SongInfo
{
    private static SongInfo instance;

    private AudioClip music;
    private TextAsset sheet;
    private VideoClip BGA;
    private Sprite sprite;

    public static SongInfo Instance {
        get {
            if(instance == null)
                instance = new SongInfo();
            return instance;
        }
    }
    public void SetInfo(AudioClip _music, TextAsset _sheet, VideoClip _BGA, Sprite _sprite) {
        this.music = _music;
        this.sheet = _sheet;
        this.BGA = _BGA;
        this.sprite = _sprite;
    }
    public AudioClip getMusic() {
        return music;
    }
    public TextAsset getSheet() {
        return sheet;
    }
    public VideoClip getBGA() {
        return BGA;
    }
    public Sprite getSprite() {
        return sprite;
    }
}
