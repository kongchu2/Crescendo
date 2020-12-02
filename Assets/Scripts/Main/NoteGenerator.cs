using System.Collections.Generic;
using UnityEngine;

public class NoteGenerator : MonoBehaviour
{
    private int[] listIndex;
    public static List<NoteInfo>[] noteTimeList;

    public GameObject[] notePrefabList;
    
    public Transform Lanes;
    public static Transform[] SpawnPosList;

    private void Awake()
    {
        listIndex = new int[Setting.Instance.key];

        noteTimeList = new List<NoteInfo>[Setting.Instance.key];
        for(int i=0;i<Setting.Instance.key;i++)
            noteTimeList[i] = new List<NoteInfo>();

        SpawnPosList = new Transform[Setting.Instance.key];
        for(int i=0;i<Setting.Instance.key;i++)
            SpawnPosList[i] = Lanes.GetChild(i);
    }
    private void Update()
    {
        if(!Record.Instance.isGameOver)
            NoteGenerate();
    }
    private void NoteGenerate()
    {
        for (int i = 0; i < Setting.Instance.key; i++)
        {
            if (noteTimeList[i].Count == listIndex[i])
                continue;
            float noteSpawnLeftTime = (MusicManager.currentMusicTime - noteTimeList[i][listIndex[i]].noteTime) * -Setting.Instance.userSpeedRate;
            if (noteSpawnLeftTime-1 <= SpawnPosList[i].position.y)
            {
                NoteInfo noteInfo = noteTimeList[i][listIndex[i]++];
                GameObject note = Instantiate(notePrefabList[i],//풀링
                new Vector2(SpawnPosList[i].position.x, //x
                            SpawnPosList[i].position.y),//y
                            Quaternion.identity,//Rotation
                            SpawnPosList[i]);//Parent
                note.GetComponent<Note>().myTime = noteInfo.noteTime;
                if (noteInfo.longNoteTime > 0)
                    note.transform.localScale = new Vector3(1f, noteInfo.longNoteTime, 1f);
            }
        }
    }   
}