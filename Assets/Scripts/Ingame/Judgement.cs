using System.Collections.Generic;
using UnityEngine;
public class Judgement
{
    public static Queue<NoteInfo>[] noteTimeQueue;
    public JudgementInfo[] judgementInfos = {
        new JudgementInfo("320", 0.0165f, 320, false),
        new JudgementInfo("300", 0.0405f, 300, false),
        new JudgementInfo("200", 0.0735f, 200, false),
        new JudgementInfo("100", 0.1035f, 100, false),
        new JudgementInfo("50", 0.1275f, 50, false),
        new JudgementInfo("0", 0.3f, 0, true)
    };

    public Judgement() {
        noteTimeQueue = new Queue<NoteInfo>[GameManager.KEY];
        for(int i=0;i<noteTimeQueue.Length;i++)
            noteTimeQueue[i] = new Queue<NoteInfo>();
    }
    public void JudgementNote(bool[] inputs, bool[] canPress)
    {
        for(int laneNum=0;laneNum<inputs.Length;laneNum++) {
            if(inputs[laneNum] && canPress[laneNum]) {
                if(noteTimeQueue[laneNum].Count == 0)
                    continue;
                float noteTime = noteTimeQueue[laneNum].Peek().noteTime;
                int judge = TimeJudgement(noteTime, laneNum);
                UIManager.Instance.setJudgementUI(judge);
                canPress[laneNum] = false;
            }
        }
    }
    private int TimeJudgement(float pressTime,int laneNum)
    {
        float musicTime = MusicManager.currentMusicTime;//음악시간
        float errorTime = Mathf.Abs(musicTime - pressTime);//음악시간-누른시간=누른시간차이
        for(int i=0;i<judgementInfos.Length;i++)
        {
            if(errorTime <= judgementInfos[i].time)
            {
                if(NoteManager.SpawnPosList[laneNum].childCount != 0)//가장 아래에 있는 노트 삭제
                    Object.Destroy(NoteManager.SpawnPosList[laneNum].GetChild(0).gameObject);
                if(judgementInfos[i].comboBreak)//콤보깨지는판정이면 콤보깨짐
                    Combo.ComboBreak();
                else {
                    Combo.combo++;
                    AnimationManager.HitPlay(laneNum);
                }
                GameManager.score += judgementInfos[i].score;
                return i;
            }
        }
        return 6;
    }
}