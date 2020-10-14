using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance = null;
    
    void Awake()
    {
        if(null == instance)
            instance = this;
    }
    public static UIManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    public Text comboUI;
    public Text scoreUI;

    public Image JudgementUI;
    public Sprite[] judgementSprites;

    private float currentTime;
    public float judgementRemoveDelay;

    void Update()
    {
        RefreshUI();
    }
    private void RefreshUI()
    {
        comboUI.text = Combo.combo.ToString();
        scoreUI.text = GameManager.score.ToString();
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
    public void setJudgementUI(int SpriteNum) {
        JudgementUI.sprite = judgementSprites[SpriteNum];
    }
}
