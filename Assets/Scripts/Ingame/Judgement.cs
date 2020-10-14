using System.Collections.Generic;
using UnityEngine;
public class Judgement
{
    public static Queue<NoteInfo>[] noteTimeQueue;
    public JudgementInfo[] judgementInfos;

    public Judgement() {
        noteTimeQueue = new Queue<NoteInfo>[GameManager.KEY];
        for(int i=0;i<noteTimeQueue.Length;i++)
            noteTimeQueue[i] = new Queue<NoteInfo>();
        judgementInfos = new JudgementInfo[6];
        judgementInfos[0] = new JudgementInfo("marvelous", 0.0165f, 320, false);
        judgementInfos[1] = new JudgementInfo("perfect", 0.0405f, 300, false);
        judgementInfos[2] = new JudgementInfo("great", 0.0735f, 200, false);
        judgementInfos[3] = new JudgementInfo("good", 0.1035f, 100, false);
        judgementInfos[4] = new JudgementInfo("bad", 0.1275f, 50, false);
        judgementInfos[5] = new JudgementInfo("idot", 0.3f, 0, true);
    }
    public void JudgementNote(bool[] inputs, bool[] canPress)
    {
        for(int laneNum=0;laneNum<inputs.Length;laneNum++) {
            if(inputs[laneNum] && canPress[laneNum]) {
                if(noteTimeQueue[laneNum].Count == 0)
                    continue;
                float noteTime = noteTimeQueue[laneNum].Peek().noteTime;
                int judge = TimeJudgement(noteTime, laneNum);
                //particle 
                AnimationManager.HitPlay(laneNum);
                //UI
                UIManager.Instance.setJudgementUI(judge);
                //input
                canPress[laneNum] = false;
            }
        }
    }
    private int TimeJudgement(float pressTime,int laneNum)
    {
        float musicTime = MusicManager.currentMusicTime;
        float errorTime = Mathf.Abs(musicTime - pressTime);
        for(int i=0;i<6;i++)
        {
            if(errorTime <= judgementInfos[i].time)
            {
                if(NoteManager.SpawnPosList[laneNum].childCount != 0)
                    Object.Destroy(NoteManager.SpawnPosList[laneNum].GetChild(0).gameObject);
                if(judgementInfos[i].comboBreak)
                    Combo.ComboBreak();
                else
                    Combo.combo++;
                GameManager.score += judgementInfos[i].score;
                return i;
            }
        }
        return 6;
    }
}