using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
public class ResultUIManager : MonoBehaviour{
    public Text scoreUI;
    public Text comboUI;
    public Text avgScoreUI;
    public Text rankUI;

    public Image songImage;

    private Dictionary<int, string> ranks;
    private void Awake() {
        ranks = new Dictionary<int, string>();
        ranks.Add(0, "F");
        ranks.Add(100, "C");
        ranks.Add(200, "B");
        ranks.Add(250, "A");
        ranks.Add(300, "S");
        ranks.Add(320, "SS");
    }
    private void Start() {
        scoreUI.text = Record.Instance.getScore().ToString();
        comboUI.text = Record.Instance.getMaxCombo().ToString();
        int avgScore = (Record.Instance.getScore() / Record.Instance.judgementedNoteCount-4);
        if(Record.Instance.judgementedNoteCount-4 > 0) 
            avgScoreUI.text = avgScore.ToString();
        else
            avgScoreUI.text = "0";
        songImage.sprite = SongInfo.Instance.getSprite();
        foreach(KeyValuePair<int, string> item in ranks)
            if(item.Key <= avgScore)
                rankUI.text = item.Value;
    }
}