using UnityEngine;
public class Judgement
{
    public static int[] listIndex;
    public JudgementInfo[] judgementInfos = {
        new JudgementInfo("320", 0.0165f, 320, false),//marvelous
        new JudgementInfo("300", 0.0405f, 300, false),//perfect
        new JudgementInfo("200", 0.0735f, 200, false),//great
        new JudgementInfo("100", 0.1035f, 100, false),//good
        new JudgementInfo("50", 0.1275f, 50, false),//bad
        new JudgementInfo("0", 0.2f, 0, true)//idiot
    };
    public Judgement() {
        listIndex = new int[Setting.Instance.key];
    }
    public void JudgementNote(int laneNum)
    {
        if(listIndex[laneNum] == NoteGenerator.noteTimeList[laneNum].Count)
            return;
        float noteTime = NoteGenerator.noteTimeList[laneNum][listIndex[laneNum]].noteTime;
        int judge = TimeJudgement(noteTime, laneNum);
    }
    private int TimeJudgement(float pressTime,int laneNum)
    {
        float musicTime = MusicManager.currentMusicTime;//음악시간
        float errorTime = Mathf.Abs(musicTime - pressTime);//음악시간-누른시간=누른시간차이
        for(int i=0;i<judgementInfos.Length;i++) {//가장가까운판정부터
            if(errorTime <= judgementInfos[i].time) {//시간내에쳤으면
                if(!judgementInfos[i].comboBreak) {
                    Record.Instance.ComboPlus();
                    AnimationManager.HitPlay(laneNum);
                    if(NoteGenerator.SpawnPosList[laneNum].childCount != 0)//가장 아래에 있는 노트 삭제
                        Object.Destroy(NoteGenerator.SpawnPosList[laneNum].GetChild(0).gameObject);
                }
                else {//노트부분의코드와겹침
                    Record.Instance.ComboBreak(true);
                    Record.Instance.HPminusplus(-1);
                }
                Record.Instance.ScorePlus(judgementInfos[i].score);
                UIManager.Instance.currentTime = 0;
                UIManager.Instance.setJudgementSpriteByIndex(i);
                Record.Instance.judgementedNoteCount++;
                return i;
            }
        }
        return 6;
    }
}