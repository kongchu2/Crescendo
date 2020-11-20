using UnityEngine;
using UnityEngine.UI;
public class ResultUIManager : MonoBehaviour{
    public Text scoreUI;
    public Text comboUI;
    public Text avgScoreUI;

    public Image songImage;

    private void Start() {
        scoreUI.text = Record.Instance.getScore().ToString();
        comboUI.text = Record.Instance.getCombo().ToString();
        avgScoreUI.text = (Record.Instance.getScore() / Record.Instance.noteCount).ToString();
        songImage.sprite = SongInfo.Instance.getSprite();
    }
}