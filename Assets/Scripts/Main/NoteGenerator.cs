using System.Collections.Generic;
using UnityEngine;

public class NoteGenerator : MonoBehaviour
{
    public static Queue<NoteInfo>[] noteTimeQueue;

    public GameObject[] notePrefabList;
    
    public Transform Lanes;
    public static Transform[] SpawnPosList;

    private void Awake()
    {
        noteTimeQueue = new Queue<NoteInfo>[Setting.Instance.key];
        for(int i=0;i<Setting.Instance.key;i++)
            noteTimeQueue[i] = new Queue<NoteInfo>();

        SpawnPosList = new Transform[Setting.Instance.key];
        for(int i=0;i<Setting.Instance.key;i++)
            SpawnPosList[i] = Lanes.GetChild(i);
    }
    private void Update()
    {
            NoteGenerate();
    }
    private void NoteGenerate()
    {
        for (int i = 0; i < Setting.Instance.key; i++)
        {
            if (noteTimeQueue[i].Count == 0)
                continue;
            float noteSpawnLeftTime = (MusicManager.currentMusicTime - noteTimeQueue[i].Peek().noteTime) * -Setting.Instance.userSpeedRate;
            if (noteSpawnLeftTime-1 <= SpawnPosList[i].position.y)
            {
                NoteInfo noteInfo = noteTimeQueue[i].Dequeue();
                GameObject note = Instantiate(notePrefabList[i],
                new Vector2(SpawnPosList[i].position.x,//x
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