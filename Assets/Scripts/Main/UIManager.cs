using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance = null;
    void Awake() {
        instance = this;
    }
    public static UIManager Instance {
        get {
            return instance;
        }
    }
    public Text comboUI;
    public Text scoreUI;
    public Text noteSpeedRateUI;

    public Image JudgementUI;
    public Sprite[] judgementSprites;

    public GameObject PauseUI;
    
    private float currentTime;
    public float judgementRemoveDelay;

    void Update()
    {
        RefreshUI();
        JudgementUIManage();
    }
    private void RefreshUI()
    {
        comboUI.text = Record.Instance.getCombo().ToString();
        scoreUI.text = Record.Instance.getScore().ToString();
    }
    public void JudgementUIManage()
    {
        currentTime +=Time.deltaTime;
        if(currentTime > judgementRemoveDelay)
        {
            JudgementUI.sprite = judgementSprites[6];
            currentTime = 0;
        }
    }
    public void setJudgementSpriteByIndex(int SpriteNum) {
        JudgementUI.sprite = judgementSprites[SpriteNum];
    }
    public void setNoteSpeedRateUI_Text(string noteSpeed) {
        noteSpeedRateUI.text = noteSpeed;
    }
    public void setPauseUI(bool active) {
        PauseUI.SetActive(active);
    }
}
